using EFIntro;
using BloggingContext? db = new();

Console.WriteLine($"SQLite DB Located at: {db.DbPath}");

db.Add(new Blog {  Url = "First Blog"});
db.Add(new Blog {  Url = "Second Blog"});

db.SaveChanges();

Blog? blog = db.Blogs.OrderBy(b => b.BlogId).First();

Console.WriteLine("Blog url before update: {blog.Url}");

blog.Url = "First Blog But Changed";
db.SaveChanges();

blog = db.Blogs.OrderBy(b => b.BlogId).First();
Console.WriteLine("Blog url after update: {blog.Url}");


blog.Posts.Add(new Post
{
    Title = "First Post in the first Blog",
    Content = "No Content To Be Found Here"
});

db.SaveChanges();

foreach(Blog b in db.Blogs)
{
    Console.WriteLine($"Deleting Blog: {b.Url}");
    Console.WriteLine($"Amount of posts deleted: {b.Posts.Count}");
    db.Remove(b);
}
db.SaveChanges();



/*
// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();


// Read
Console.WriteLine("Querying for a blog");
var blog = db.Blogs
    .OrderBy(b => b.BlogId)
    .First();

// Update
Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(
    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
db.SaveChanges();

foreach (Blog b in db.Blogs)
{
	Console.WriteLine($"Blog: [url: {b.Url}, amount of posts: {b.Posts.Count}]");
}

// Delete
Console.WriteLine("Delete the blog");
db.Remove(blog);
db.SaveChanges();


*/