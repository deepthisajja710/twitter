using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TweetRepository
    {
        public void AddTweet(Tweet objTweet)
        {
            try
            {
                using (TweetContext objContext = new TweetContext())
                {
                    objContext.Tweets.Add(objTweet);
                    objContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Tweet> GetTweetsByName(string userid)
        {
            List<Tweet> objTweets = new List<Tweet>();
            try
            {
                using (TweetContext objContext = new TweetContext())
                {
                    var tweets = from obj in objContext.Tweets
                                 where obj.user_id == userid
                                 select obj;
                    foreach(var item in tweets)
                    {
                        objTweets.Add(new Tweet {user_id = item.user_id, tweet_id = item.tweet_id, message = item.message, created = item.created});
                    }
                }
                return objTweets;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Tweet> GetAllTweets()
        {
            List<Tweet> objTweets = new List<Tweet>();
            try
            {
                using (TweetContext objContext = new TweetContext())
                {
                    var tweets = from obj in objContext.Tweets
                                 
                                 select obj;
                    foreach (var item in tweets)
                    {
                        objTweets.Add(new Tweet { user_id = item.user_id, tweet_id = item.tweet_id, message = item.message, created = item.created });
                    }
                }
                return objTweets;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditTweet(Tweet objTweet)
        {
            try
            {
                using (TweetContext objContext = new TweetContext())
                {

                    objContext.Tweets.Attach(objTweet);
                    objContext.Entry(objTweet).State = System.Data.Entity.EntityState.Modified;
                    objContext.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteTweet(int id)
        {
            try
            {
                using (TweetContext objContext = new TweetContext())
                {
                    var query = (from obj in objContext.Tweets
                                where obj.tweet_id == id
                                select obj).FirstOrDefault();
                    objContext.Tweets.Remove(query);
                    objContext.SaveChanges();

                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Tweet FindTweet(int id)
        {
            try
            {
                using (TweetContext objContext = new TweetContext())
                {
                    var query = (from obj in objContext.Tweets
                                 where obj.tweet_id == id
                                 select obj).FirstOrDefault();
                    return query;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
