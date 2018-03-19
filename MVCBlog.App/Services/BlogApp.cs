using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MVCBlog.Crosscuting;
using MVCBlog.Domain.Data;
using MVCBlog.Domain.Entities;

namespace MVCBlog.App.Services
{
    public class BlogApp
    {
        public int Save(Essay essay) {
            try
            {
                ValidateModel(essay);

                using (var db = new BlogContext())
                {
                    essay.PublishDate = DateTime.Now;

                    db.Add(essay);
                    db.SaveChangesAsync();
                    return 1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        public List<Essay> Get(int? id, int? last, string search)
        {
            using (var db = new BlogContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    List<Essay> filteredEssays = db.Essays.AsNoTracking()
                        .Where(e => e.Title.Contains(search) || e.Subtitle.Contains(search))
                        .OrderByDescending(e => e.PublishDate).ToList();
                    return filteredEssays;
                }

                if (last.HasValue)
                {
                    List<Essay> PaginatedEssays = db.Essays.AsNoTracking()
                        .Where(e => e.Id > last.Value)
                        .OrderByDescending(e => e.PublishDate).Take(10).ToList();
                    return PaginatedEssays;
                }

                if (id.HasValue)
                {
                    Essay essay = db.Essays.AsNoTracking().Where(e => e.Id.Equals(id.Value)).FirstOrDefault();
                    return new List<Essay> {
                        essay
                    };
                }
                
                return db.Essays.ToList();
            }
        }

        private void ValidateModel(Essay essay)
        {
            if (essay == null)
                throw new ArgumentNullException(Messages.ParametersCanNotBeNull);

            if (string.IsNullOrEmpty(essay.Title))
                throw new ArgumentNullException(Messages.TitleCanNotBeNull);

            if (string.IsNullOrEmpty(essay.Title))
                throw new ArgumentNullException(Messages.TitleCanNotBeNull);
        }
    }
}
