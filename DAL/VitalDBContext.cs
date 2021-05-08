using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VitalWeb.Models;

namespace VitalWeb.DAL
{
    public class VitalDBContext : DbContext
    {

        #region Constructors

        public VitalDBContext(DbContextOptions<VitalDBContext> options) : base(options) { }

        #endregion

        #region DbSets

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<MyTagContainer> MyTagContainers { get; set; }

        #endregion

    }

    public static class PostDAL
    {

        #region Get by ID

        public static async Task<Post> GetById(VitalDBContext dBContext, int? id)
        {
            if (id == null)
            {
                Console.WriteLine("GetById() => Id is NULL");
                return null;
            }

            Post postToReturn = await dBContext.Posts
                .Include(p => p.PostTag)
                .SingleOrDefaultAsync(p => p.PostID == id);
            return postToReturn;
        }
            
        #endregion

        #region List all

        public static async Task<List<Post>> ListAll(VitalDBContext dBContext)
        {
            List<Post> allPosts = await dBContext.Posts
                .Include(p => p.PostTag)
                .ToListAsync();
            return allPosts;
        }

        #endregion

        #region Add

        public static void Add(VitalDBContext dBContext, Post postToAdd)
        {
            dBContext.Posts.Add(postToAdd);
        }

        public static async Task AddAsync(VitalDBContext dBContext, Post postToAdd)
        {
            await dBContext.Posts.AddAsync(postToAdd);
        }
            
        #endregion

        #region Update

        public static void Update(VitalDBContext dBContext, Post post)
        {
            dBContext.Update(post);
        }

        // public static async Task UpdateAsync(VitalDBContext dBContext, Post post)
        // {
        //     dBContext.Posts.Update(post);
        // }
            
        #endregion

        #region Remove

        public static void RemoveById(VitalDBContext dBContext, int id)
        {
            // var postToRemove = dBContext.Posts.Find(id);
            // dBContext.Posts.Remove(postToRemove);
            
            var postToRemove = dBContext.Posts
                .FirstOrDefault(p => p.PostID == id);
            dBContext.Posts.Remove(postToRemove);
        }

        public static async Task RemoveByIdAsync(VitalDBContext dbContext, int id)
        {
            var post = await dbContext.Posts.FindAsync(id);
            dbContext.Posts.Remove(post);
        }
            
        #endregion

        #region SQL Raw
        
        public static async Task<List<Post>> GetAllFromSqlRaw(VitalDBContext dBContext)
        {
            List<Post> allPosts = await dBContext.Posts
                .FromSqlRaw("SELECT * FROM Posts")
                .ToListAsync();
                dBContext.Dispose();
                return allPosts;
        }
            
        #endregion

        #region Save

        public static void Save(VitalDBContext dBContext)
        {
            dBContext.SaveChanges();
            dBContext.Dispose();
        }

        public static async Task SaveAsync(VitalDBContext dbContext)
        {
            await dbContext.SaveChangesAsync();
            dbContext.Dispose();
        }
            
        #endregion
        
    }
    
    // namespace Namespace
    // {
    //     public class VitalDBContext : IVitalDBContext
    //     {
    //         private readonly ApplicationDbContext _dbContext;
    
    //         public VitalDBContext(ApplicationDbContext dbContext)
    //         {
    //             _dbContext = dbContext;
    //         }
    
    //         public Item Add(Item item) => _dbContext.Items.Add(item).Entity;
    
    //         public void Remove(Item item) => _dbContext.Items.Remove(item);
    
    //         public IEnumerable<Item> ListAll() => _dbContext.Items.ToList();
    
    //         public Item GetById(int id) => _dbContext.Items.Find(id);
    
    //         public void Save() => _dbContext.SaveChanges();
    //     }
    // }
}