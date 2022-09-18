using DevFreela.Core.Enum;
using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {
        public Project(string title, string description, int idCliente, int idFreelancer, decimal totalCost)
        {
            Title = title;
            Description = description;
            IdCliente = idCliente;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;
            CreateAt = DateTime.Now;

            Status = ProjectStatusEnum.Created;
            Coments = new List<ProjectComment>();
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdCliente { get; private set; }
        public int IdFreelancer { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime CreateAt { get; private set; }
        public DateTime? StartdAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public List<ProjectComment> Coments { get; private set; }

        public void Cancel()
        {
            if(Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.InProgress)
            {
                Status = ProjectStatusEnum.Cancelled;
            }
        }

        public void Start()
        {
            if(Status == ProjectStatusEnum.Created)
            {
                Status = ProjectStatusEnum.InProgress;
                StartdAt = DateTime.Now;
            }
        }

        public void Finish()
        {
            if(Status == ProjectStatusEnum.InProgress)
            {
                Status = ProjectStatusEnum.Finished;
                FinishedAt = DateTime.Now;
            }
            
        }

        public void Update(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }
    }
}
