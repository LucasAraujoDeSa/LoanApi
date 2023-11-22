using System.Text.Json.Serialization;
using LoansApp.Domain.Enums;

namespace LoansApp.Domain.Etities
{
    public class LoanEntity
    {
        public LoanEntity(
            string description,
            float amount,
            DateTime openedAt,
            DateTime? closedAt,
            string status,
            string ownerId
        )
        {
            Id = Guid.NewGuid().ToString();
            Description = description;
            Amount = amount;
            OpenedAt = openedAt;
            ClosedAt = closedAt;
            Status = status;
            OwnerId = ownerId;
        }

        public string Id { get; private set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public DateTime OpenedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public string Status { get; set; }
        public string OwnerId { get; set; }
        [JsonIgnore]
        public virtual UserEntity Owner { get; set; } = null!;
    }
}