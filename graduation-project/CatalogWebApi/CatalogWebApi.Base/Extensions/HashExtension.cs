﻿namespace CatalogWebApi.Base
{
    public static class HashExtension
    {        
        public static bool CheckingPassword(this string storagePassword, string loginPassword)
        {           
            try
            {
                if (string.Equals(storagePassword, loginPassword))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
