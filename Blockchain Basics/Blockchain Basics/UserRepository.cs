using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blockchain_Basics;
using Firebase.Database;
using Newtonsoft.Json;

namespace BlockchainBasics
{
    public class UserRepository
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://blockchain-basics-d5943-default-rtdb.europe-west1.firebasedatabase.app");

        public async Task<bool> SaveUser(User user)
        {
            var data = await firebaseClient.Child(nameof(User)).PostAsync(JsonConvert.SerializeObject(user));

            if (string.IsNullOrEmpty(data.Key))
            {
                return false;
            }

            return true;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return (await firebaseClient.Child(nameof(User)).OnceAsync<User>()).Select(item => new User
            {
                UserName = item.Object.UserName,
                UserPassword = item.Object.UserPassword,
                UserProgress = item.Object.UserProgress,
                UserLessonsProgress = item.Object.UserLessonsProgress,
                UserGamesProgress = item.Object.UserGamesProgress,
                UserSelectedLessons = item.Object.UserSelectedLessons,
                UserProfile = item.Object.UserProfile,
                UserAchievements = item.Object.UserAchievements,
                UserPrimogames = item.Object.UserPrimogames,
                Id = item.Key,
            }).ToList();
        }

        public async Task<User> GetByIdUser(string id)
        {
            return (await firebaseClient.Child(nameof(User) + "/" + id).OnceSingleAsync<User>());
        }

        public async Task<bool> Update(User user)
        {
            await firebaseClient.Child(nameof(User) + "/" + user.Id).PutAsync(JsonConvert.SerializeObject(user));
            return true;
        }

    }
}

