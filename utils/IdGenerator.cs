namespace IdGenerator
{
    public class IdGeneratorClass
    {
        private string keys = "0123456789";
        public string IdGenerator(string role, int idLength = 12)
        {
            string id = "";
            Random rand = new Random();
            if (role == "student")
            {
                id += "STU";
            }
            else if (role == "teacher")
            {
                id += "TCH";
            }
            else if (role == "organization")
            {
                id += "ORG";
            }
            else
            {
                return "Invalid Role";
            }
            for (int i = 0; i < idLength; i++)
            {
                id += keys[rand.Next(0, keys.Length)];
            }
            return id;
        }
        public string OrgIdsGenerator(string orgId, string role)
        {
            string[] tmp = orgId.Split(orgId[orgId.Length / 2]);
            if (role == "student")
            {
                return tmp[0] + "0" + tmp[1];
            }
            else if (role == "teacher")
            {
                return tmp[0] + "1" + tmp[1];
            }
            else
            {
                return "Invalid Role";
            }
        }
    }
}