using CarBook.Application.RepositoryPattern;
using CarBook.Domain.Entites;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CommentRepositories
{
	public class CommentRepositroy<T> : IGenericRepository<Comment>
	{
		private readonly CarBookContext _context;
		public CommentRepositroy(CarBookContext context)
		{
			_context = context;
		}
		public void Create(Comment entity)
		{
			_context.Comments.Add(entity);
			_context.SaveChanges();
		}

		public List<Comment> GetAll()
		{
			return _context.Comments.Select(x => new Comment
			{
				CommentID = x.CommentID,
				Name = x.Name,
				Description = x.Description,
				CreatedDate = x.CreatedDate,
				BlogId = x.BlogId
			}).ToList();	
		}

		public Comment GetById(int id)
		{
			return _context.Comments.FirstOrDefault(x => x.CommentID == id);
		}

        public List<Comment> GetCommentByBlogId(int id)
        {
			return _context.Set<Comment>().Where(x => x.BlogId == id).ToList();
        }

        public void Remove(Comment entity)
		{
			var value = _context.Comments.FirstOrDefault(x => x.CommentID == entity.CommentID);
			_context.Comments.Remove(value);
			_context.SaveChanges();
		}

		public void Update(Comment entity)
		{
			_context.Comments.Update(entity);
			_context.SaveChanges();
		}
		public int GetCountCommentByBlog(int id)
		{
			return _context.Comments.Where(x => x.BlogId == id).Count();
		}
	}
}
