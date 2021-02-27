using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MMO_EFCore
{
    //public struct ItemOption
    //{
    //    public int str;
    //    public int dex;
    //    public int hp;
    //}

    //public class ItemOption
    //{
    //    public int Str { get; set; }
    //    public int Dex { get; set; }
    //    public int Hp { get; set; }
    //}

    //public class ItemDetail
    //{
    //    public int ItemDetailId { get; set; }
    //    public string Description { get; set; }
    //}

    //public enum ItemType
    //{
    //    NormalItem,
    //    EventItem
    //}

    //public class ItemReview
    //{
    //    public int ItemReviewId { get; set; }
    //    public int Score { get; set; } // 0~5
    //}    

    [Table("Item")]
    public class Item
    {
        //private string _jsonData;
        //public string JsonData
        //{
        //    get { return _jsonData; }
        //    set { _jsonData = value; }
        //}

        //public void SetOption(ItemOption option)
        //{
        //    _jsonData = JsonConvert.SerializeObject(option);
        //}

        //public ItemOption GetOption()
        //{
        //    return JsonConvert.DeserializeObject<ItemOption>(_jsonData);
        //}

        //public ItemType Type { get; set; }
        public bool SoftDeleted { get; set; }

        //public ItemOption Option { get; set; }
        //public ItemDetail Detail { get; set; }
        // [name]Id -> PK
        public int ItemId { get; set; }
        public int TemplateId { get; set; } // 101
        //public DateTime CreateDate { get; set; } = new DateTime(2020, 1, 1);
        public DateTime CreateDate { get; private set; }
       
        public int ItemGrade { get; set; }

        // [ForeignKey("Owner")]
         public int TestOwnerId { get; set; }
        // public int OwnerId { get; set; }
        // [ForeignKey("ItemId, TemplateId")]
        // [ForeignKey("OwnerId")]
        //[InverseProperty("OwnedItem")]
        public Player Owner { get; set; }

        //public int? TestCreatorId { get; set; }
        //public Player Creator { get; set; }

        //public ICollection<ItemReview> Reviews { get; set; }
        
        //public double? AverageScore { get; set; }

        //private readonly List<ItemReview> _reviews = new List<ItemReview>();
        //public IEnumerable<ItemReview> Reviews { get { return _reviews.ToList(); } }

        //public void AddReview(ItemReview review)
        //{
        //    _reviews.Add(review);
        //    AverageScore = _reviews.Any() ? _reviews.Average(r => r.Score) : (double?)null;
        //}

        //public void RemoveReview(ItemReview review)
        //{
        //    _reviews.Remove(review);
        //}
    }
    
    //public class EventItem : Item
    //{
    //    public DateTime DestroyDate { get; set; }
    //}

    public class PlayerNameGenerator : ValueGenerator<string>
    {
        public override bool GeneratesTemporaryValues => false;

        public override string Next(EntityEntry entry) 
        {
            string name = $"Player_{DateTime.Now.ToString("yyyyMMdd")}";
            return name;
        }
    }

    // detect Created Time
    public interface ILogEntity
    {
        DateTime CreateTime { get; }
        void SetCreateTime();

    }

    [Table("Player")]
    public class Player
    {
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        //[InverseProperty("Owner")]
        public Item OwnedItem { get; set; }
        //[InverseProperty("Creator")]
        //public ICollection<Item> CreatedItems { get; set; }

        //public ICollection<Item> Items { get; set; }
        //public Item Item { get; set; }
        public Guild Guild { get; set; }

        public DateTime CreateTime { get; private set; }

        public void SetCreateTime()
        {
            CreateTime = DateTime.Now;
        }
    }

    [Table("Guild")]
    public class Guild
    {
        public int GuildId { get; set; }
        public string GuildName { get; set; }
        public ICollection<Player> Members { get; set; }
    }

    public class GuildDto
    {
        public int GuildId { get; set; }
        public string Name { get; set; }
        public int MemberCount { get; set; }
    }
}
