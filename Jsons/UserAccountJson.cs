using System;
using System.ComponentModel.DataAnnotations;
using BidNexus.Models;

namespace BidNexus.Jsons
{
    public class UserAccountJson
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(30)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public string? ProfileImgUrl { get; set; }

        public string? Address { get; set; }

        public DateTime CreateDate { get; set; }

        public int CreateBy { get; set; }

        public DateTime UpdateDate { get; set; }

        public int UpdateBy { get; set; }

        public bool IsDeleted { get; set; }
        public string RetypePassword { get; set; }
        public string Password {get; set; }
        public byte UserTypeEnumId {get; set; }
    }

    public static partial class EntityMapper
    {
        public static void Map(this UserAccount entity, UserAccountJson toJson)
        {
            toJson.Id = entity.Id;
            toJson.FullName = entity.FullName;
            toJson.UserName = entity.UserName;
            toJson.Email = entity.Email;
            toJson.ProfileImgUrl = entity.ProfileImgUrl;
            toJson.Address = entity.Address;
            toJson.CreateDate = entity.CreateDate;
            toJson.CreateBy = entity.CreateBy;
            toJson.UpdateDate = entity.UpdateDate;
            toJson.UpdateBy = entity.UpdateBy;
            toJson.IsDeleted = entity.IsDeleted;
            toJson.UserTypeEnumId=entity.UserTypeEnumId;
        }

        public static void Map(this UserAccountJson json, UserAccount toEntity)
        {
            toEntity.Id = json.Id;
            toEntity.FullName = json.FullName;
            toEntity.UserName = json.UserName;
            toEntity.Email = json.Email;
            toEntity.ProfileImgUrl = json.ProfileImgUrl;
            toEntity.Address = json.Address;
            toEntity.CreateDate = json.CreateDate;
            toEntity.CreateBy = json.CreateBy;
            toEntity.UpdateDate = json.UpdateDate;
            toEntity.UpdateBy = json.UpdateBy;
            toEntity.IsDeleted = json.IsDeleted;
            toEntity.UserTypeEnumId=json.UserTypeEnumId;
        }
    }
}