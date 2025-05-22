namespace BidNexus.Models
{
    public partial class UserAccount
    {
        public enum UserTypeEnum
        {
            GeneralUser = 0,
            Admin = 1
        }
        public static UserAccount GetNew(int id = 0)
        {
            var obj = new UserAccount();
            obj.Id = 0;
            obj.FullName = string.Empty;
            obj.UserName = string.Empty;
            obj.Email = string.Empty;
            obj.ProfileImgUrl = null;
            obj.Address = null;
            obj.CreateDate = DateTime.Now;
            obj.CreateBy = 0;
            obj.UpdateDate = DateTime.Now;
            obj.UpdateBy = 0;
            obj.IsDeleted = false;
            obj.PasswordHash = string.Empty;
            obj.PasswordSalt = string.Empty;
            obj.UserTypeEnumId = (int)UserAccount.UserTypeEnum.GeneralUser;
            return obj;
        }
    }
}
