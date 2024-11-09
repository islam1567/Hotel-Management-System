using Hotel_Management_System.Cores.AppDbContext;
using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Hotel_Management_System.Cores.Repository
{
    public class FeedBacksRepo : IRepository<FeedBacksDto>
    {
        private readonly ApplicationDbContext context;

        public FeedBacksRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<FeedBacksDto> GetAll()
        {
            var result = context.FeedBacks.
                Select(e => new  FeedBacksDto
                {
                    Id = e.Id,
                    Rating = e.Rating,
                    Comment = e.Comment,
                    CreatedAt = e.CreatedAt,
                    UserId = e.UserId,
                    ReservationId = e.ReservationId,
                }).ToList();
            return result;
        }

        public FeedBacksDto GetById(int id)
        {
            var result = context.FeedBacks.
                Select(e => new FeedBacksDto
                {
                    Id = e.Id,
                    Rating = e.Rating,
                    Comment = e.Comment,
                    CreatedAt = e.CreatedAt,
                    UserId = e.UserId,
                    ReservationId = e.ReservationId,
                }).FirstOrDefault(e => e.Id == id);
            return result;
        }

        public void Add(FeedBacksDto Dto)
        {
            var feed = new FeedBacks
            {
                Id = Dto.Id,
                Rating = Dto.Rating,
                Comment = Dto.Comment,
                CreatedAt = Dto.CreatedAt,
                UserId = Dto.UserId,
                ReservationId = Dto.ReservationId,
            };
            context.FeedBacks.Add(feed);
            context.SaveChanges();
        }

        public void Update(int id, FeedBacksDto Dto)
        {
            var feed = context.FeedBacks.FirstOrDefault(e => e.Id == id);
            feed.Id = Dto.Id;
            feed.Rating = Dto.Rating;
            feed.Comment = Dto.Comment;
            feed.CreatedAt = Dto.CreatedAt;
            feed.UserId = Dto.UserId;
            feed.ReservationId = Dto.ReservationId;
            context.SaveChanges();
        }

        public void Dalete(int id)
        {
            var feed = context.FeedBacks.FirstOrDefault(e => e.Id == id);
            context.FeedBacks.Remove(feed);
            context.SaveChanges();
        }

    }
}
