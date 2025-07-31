using LVS.Utils.Configuration;
using System;
using System.IO;
using System.Web;

namespace LVS.Api.ImageStorage
{
    public static class ImageStoreHelper
    {
        public static string UpdateUserProfileImage(string profileImagePath, HttpPostedFile file)
        {
            if (file == null)
                throw new ArgumentException("file");

            var storeFolderName = ConfigurationHelper.GetValue<string>("CMS.User.ProfilePictureFolderName");

            if (string.IsNullOrWhiteSpace(storeFolderName))
                throw new ArgumentException("profile picture folder name");

            var relativePath = System.Web.HttpContext.Current.Server.MapPath("~");

            if (!Directory.Exists(string.Format("{0}{1}", relativePath, storeFolderName)))
                Directory.CreateDirectory(string.Format("{0}{1}", relativePath, storeFolderName));

            if (!string.IsNullOrWhiteSpace(file.ContentType) && ConfigurationHelper.GetValue<string>("CMS.User.ProfilePicture.ContentType.Allowed") != null && !ConfigurationHelper.GetValue<string>("CMS.User.ProfilePicture.ContentType.Allowed").Contains(file.ContentType.Replace("image/", string.Empty)))
                throw new ArgumentException("profile picture content type");

            if (ConfigurationHelper.GetValue<double>("CMS.User.ProfilePicture.MaxContentLength.Bytes") < file.ContentLength)
                throw new ArgumentException("profile picture content size");

            var fileName = string.Format("{0}{1}", Guid.NewGuid(), Path.GetExtension(file.FileName));

            // stores new profile image
            file.SaveAs(string.Format("{0}{1}/{2}", relativePath, storeFolderName, fileName));

            // deletes old profile image path
            if (!string.IsNullOrWhiteSpace(profileImagePath) && File.Exists(string.Format("{0}{1}", relativePath, profileImagePath)))
                File.Delete(string.Format("{0}{1}", relativePath, profileImagePath));

            return string.Format("{0}/{1}", storeFolderName, fileName);
        }
    }
}