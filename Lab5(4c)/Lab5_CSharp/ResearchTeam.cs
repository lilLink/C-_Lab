using System.Runtime.Serialization.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Lab5_CSharp
{
    [DataContract]
    class ResearchTeam : Team, INameAndCopy, IComparer<ResearchTeam>
    {
        private string _researchTeamTopic;
        private string _researchTeamOrganization;
        private int _researchTeamNumber;
        private TimeFrame _researchTeamTimeFrame;
        List<Paper> _researchTeamPaperList = new List<Paper>(); 
        List<Person> _researchTeamPersonList = new List<Person>();

        [DataMember]
        public string ReseachTeamTopic { get => _researchTeamTopic; set => _researchTeamTopic = value; }
        [DataMember]
        public string ReseachTeamOrganization { get => _researchTeamOrganization; set => _researchTeamOrganization = value; }
        [DataMember]
        public int ReseachTeamNumber { get => _researchTeamNumber; set => _researchTeamNumber = value; }
        [DataMember]
        public TimeFrame ResearchTeamTimeframe { get => _researchTeamTimeFrame; set => _researchTeamTimeFrame = value; }
        [DataMember]
        public List<Paper> ResearchTeamPaperList { get => _researchTeamPaperList; set => _researchTeamPaperList = value; }
        [DataMember]
        public List<Person> ResearchTeamPersonList { get => _researchTeamPersonList; set => _researchTeamPersonList = value; }


        public ResearchTeam(string topic, string organization, int number, TimeFrame timeframe) : base(organization, number)
        {
            _researchTeamTopic = topic;
            _researchTeamTimeFrame = timeframe;
        }

        public ResearchTeam() : base()
        {
            _researchTeamTopic = "Topic";
            _researchTeamTimeFrame = TimeFrame.YEAR;
        }

        [DataMember]
        public Paper LastPaper
        {
            get
            {
                if (!_researchTeamPaperList.Any())
                    return null;


                int i = 0;
                int newestPaperIndex = 0;

                foreach (Paper paper in _researchTeamPaperList)
                {
                    if (paper.Date > _researchTeamPaperList[newestPaperIndex].Date)
                        newestPaperIndex = i;

                    i++;

                }

                return _researchTeamPaperList[newestPaperIndex];

            }
            set { }
        }

        public bool this[TimeFrame time]
        {
            get
            {
                if (_researchTeamTimeFrame == time)
                    return true;

                return false;
            }
        }

        public void AddPapers(params Paper[] array)
        {
            _researchTeamPaperList.AddRange(array);

        }

        public void AddMembers(params Person[] list)
        {
            _researchTeamPersonList.AddRange(list);
        }

        public override string ToString()
        {
            string researchTeamDataStr = " ";


            researchTeamDataStr = _researchTeamTopic + " "
                                 + base.ToString() + "  "
                                 + _researchTeamTimeFrame + " "
                                 + researchTeamDataStr;

            if (_researchTeamPaperList != null && _researchTeamPersonList != null)
            {

                foreach (Person person in _researchTeamPersonList)
                    researchTeamDataStr = researchTeamDataStr + " " + person.FirstName;

                foreach (Paper paper in _researchTeamPaperList)
                    researchTeamDataStr = researchTeamDataStr + " " + paper.Name;
            }
            return researchTeamDataStr;
        }

        public virtual string ToShortString()
        {
            return "Topic: " + _researchTeamTopic + " " + base.ToString() + " " + "Time frame: " + _researchTeamTimeFrame + "\n";
        }

        public new object DeepCopy()
        {
            ResearchTeam reserchTeamCopy = new ResearchTeam(_researchTeamTopic, name, teamNum, _researchTeamTimeFrame);
            reserchTeamCopy._researchTeamPaperList = _researchTeamPaperList;
            reserchTeamCopy._researchTeamPersonList = _researchTeamPersonList;
            return reserchTeamCopy as object;
        }

        public Team Team
        {
            get
            {
                return new Team("name", 444);
            }

            set
            {
                name = value.Name;
                teamNum = value.TeamNum;
            }
        }

        public IEnumerable<Person> GetPersonEnumerator()
        {
            bool FoundMatch;

            for (int WorkerIndex = 0; WorkerIndex < _researchTeamPersonList.Count; WorkerIndex++)
            {

                FoundMatch = false;

                for (int PaperIndex = 0; PaperIndex < _researchTeamPaperList.Count; PaperIndex++)
                {

                    if (_researchTeamPaperList.ElementAt(PaperIndex).Author == _researchTeamPersonList.ElementAt(WorkerIndex))
                    {
                        FoundMatch = true;
                        break;
                    }

                }
                if (!FoundMatch)
                    yield return _researchTeamPersonList.ElementAt(WorkerIndex);
            }
        }

        public IEnumerable<Paper> GetPublicationsEnumerator(int inputTimeRange)
        {
            DateTime inputTimeFrame = new DateTime(((int)DateTime.Now.Year - inputTimeRange), 1, 1, 1, 1, 1);
            for (int index = 0; index < _researchTeamPaperList.Count; index++)
            {
                if (_researchTeamPaperList[index].Date.Ticks > inputTimeFrame.Ticks)
                    yield return _researchTeamPaperList[index]; 
            }
        }

        public IEnumerable<Person> GetWorkersEnumerator()
        {

            bool FoundMatch;

            for (int WorkerIndex = 0; WorkerIndex < _researchTeamPersonList.Count; WorkerIndex++)
            {

                FoundMatch = false;

                for (int PaperIndex = 0; PaperIndex < _researchTeamPaperList.Count; PaperIndex++)
                {

                    if (_researchTeamPaperList.ElementAt(PaperIndex).Author == _researchTeamPersonList.ElementAt(WorkerIndex))
                    {
                        FoundMatch = true;
                        break;
                    }

                }
                if (FoundMatch)
                    yield return _researchTeamPersonList.ElementAt(WorkerIndex);
            }
        }

        public IEnumerable<Person> GetGoodWorkersEnumerator()
        {
            bool FoundMatch;
            int hasWorks = 0;

            for (int WorkerIndex = 0; WorkerIndex < _researchTeamPersonList.Count; WorkerIndex++)
            {
                hasWorks = 0;
                FoundMatch = false;

                for (int PaperIndex = 0; PaperIndex < _researchTeamPaperList.Count; PaperIndex++)
                {

                    if (_researchTeamPaperList.ElementAt(PaperIndex).Author == _researchTeamPersonList.ElementAt(WorkerIndex))
                    {
                        FoundMatch = true;
                        hasWorks++;
                        break;
                    }

                }
                if (FoundMatch && hasWorks > 1)
                    yield return _researchTeamPersonList.ElementAt(WorkerIndex);
            }
        }

        public IEnumerable<Paper> GetYearPublicationsEnumerator()
        {
            DateTime inputTimeFrame = new DateTime(((int)DateTime.Now.Year - 1), 1, 1, 1, 1, 1);
            for (int index = 0; index < _researchTeamPaperList.Count; index++)
            {
                if (_researchTeamPaperList[index].Date.Ticks > inputTimeFrame.Ticks)
                    yield return _researchTeamPaperList[index];
            }

        }

        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            return x._researchTeamTopic.CompareTo(y._researchTeamTopic);
        }

        public static T DeepCopy<T>(object obj) where T : class
        {
            if (obj is T serialisedObject)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                    try
                    {
                        serializer.WriteObject(ms, serialisedObject);
                        ms.Position = 0;
                        return serializer.ReadObject(ms) as T;
                    }
                    catch (InvalidDataContractException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (SerializationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        ms.Close();
                    }
                }
            }
            throw new ArgumentException($"I cannot convert { nameof(serialisedObject) } to ResearchTeam");
        }

        public static bool Load(string fileName, ResearchTeam researchTeam)
        {
            string fileLocation = @"D:\";
            string fileFormat = ".txt";

            try
            {
                using (FileStream fstream = File.OpenRead(fileLocation + fileName + fileFormat))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    string json = Encoding.Default.GetString(array);

                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                    ResearchTeam deserializedTeam = new ResearchTeam();
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedTeam.GetType());
                    deserializedTeam = ser.ReadObject(ms) as ResearchTeam;

                    researchTeam.ReseachTeamTopic = deserializedTeam.ReseachTeamTopic;
                    researchTeam.ReseachTeamOrganization = deserializedTeam.ReseachTeamOrganization;
                    researchTeam.ResearchTeamTimeframe = deserializedTeam.ResearchTeamTimeframe;
                    researchTeam.ReseachTeamNumber = deserializedTeam.ReseachTeamNumber;
                    researchTeam.ResearchTeamPaperList = deserializedTeam.ResearchTeamPaperList;
                    researchTeam.ResearchTeamPersonList = deserializedTeam.ResearchTeamPersonList;

                    ms.Close();
                    fstream.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public static bool Save(string fileName, ResearchTeam saveResearchTeam)
        {
            string fileLocation = @"D:\";
            string fileFormat = ".txt";

            ResearchTeam researchTeam = new ResearchTeam(saveResearchTeam.ReseachTeamTopic, saveResearchTeam.ReseachTeamOrganization, saveResearchTeam.ReseachTeamNumber, saveResearchTeam.ResearchTeamTimeframe);
            researchTeam.ResearchTeamPaperList = saveResearchTeam.ResearchTeamPaperList;
            researchTeam.ResearchTeamPersonList = saveResearchTeam.ResearchTeamPersonList;

            MemoryStream ms = new MemoryStream();
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ResearchTeam));
                ser.WriteObject(ms, researchTeam);
                byte[] json = ms.ToArray();

                var objectToJson = Encoding.UTF8.GetString(json, 0, json.Length);
                FileStream fstream = new FileStream(fileLocation + fileName + fileFormat, FileMode.OpenOrCreate);
                fstream.SetLength(0);
                byte[] array = Encoding.Default.GetBytes(objectToJson);
                fstream.Write(array, 0, array.Length);
                fstream.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                ms.Close();
            }
            return false;
        }

        public bool Save(string fileName)
        {
            string fileLocation = @"D:\";
            string fileFormat = ".txt";

            ResearchTeam researchTeam = new ResearchTeam(ReseachTeamTopic, ReseachTeamOrganization, ReseachTeamNumber, ResearchTeamTimeframe);
            researchTeam.ResearchTeamPaperList = ResearchTeamPaperList;
            researchTeam.ResearchTeamPersonList = ResearchTeamPersonList;

            MemoryStream ms = new MemoryStream();
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ResearchTeam));
                ser.WriteObject(ms, researchTeam);
                byte[] json = ms.ToArray();

                var objectToJson = Encoding.UTF8.GetString(json, 0, json.Length);
                FileStream fstream = new FileStream(fileLocation + fileName + fileFormat, FileMode.OpenOrCreate);
                fstream.SetLength(0);
                byte[] array = Encoding.Default.GetBytes(objectToJson);
                fstream.Write(array, 0, array.Length);
                fstream.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                ms.Close();
            }
            return false;
        }

        public bool Load(string fileName)
        {
            string fileLocation = @"D:\";
            string fileFormat = ".txt";

            try
            {
                using (FileStream fstream = File.OpenRead(fileLocation + fileName + fileFormat))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    string json = Encoding.Default.GetString(array);

                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                    ResearchTeam deserializedTeam = new ResearchTeam();
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedTeam.GetType());
                    deserializedTeam = ser.ReadObject(ms) as ResearchTeam;

                    ReseachTeamTopic = deserializedTeam.ReseachTeamTopic;
                    ReseachTeamOrganization = deserializedTeam.ReseachTeamOrganization;
                    ResearchTeamTimeframe = deserializedTeam.ResearchTeamTimeframe;
                    ReseachTeamNumber = deserializedTeam.ReseachTeamNumber;
                    ResearchTeamPaperList = deserializedTeam.ResearchTeamPaperList;
                    ResearchTeamPersonList = deserializedTeam.ResearchTeamPersonList;

                    ms.Close();
                    fstream.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public bool AddPaperFromConsole()
        {
            Console.WriteLine("Введiть данi для об'єкту Paper наступного формату: " +
                              "назва публiкацiї;дата публiкацiї;Автор: iм'я;прiзвище;дата народження(формат: YYYY:MM:DD)\n" +
                              "Приклад: C# tutorial;2020-03-30;James;Bay;1990-04-23");

            Person person = new Person();
            Paper paper = new Paper();
            var input = Console.ReadLine();
            string[] splitedString = new string[] { "" };

            if (input != null)
            {
                splitedString = input.Split(';');
            }

            try
            {
                paper.Name = splitedString[0];
                var yearOfPublishing = int.Parse(splitedString[1].Split('-')[0]);
                var monthOfPublishing = int.Parse(splitedString[1].Split('-')[1]);
                var dayOfPublishing = int.Parse(splitedString[1].Split('-')[2]);
                paper.Date = new DateTime(yearOfPublishing, monthOfPublishing, dayOfPublishing);

                person.FirstName = splitedString[2];
                person.LastName = splitedString[3];
                var yearOfBirth = int.Parse(splitedString[4].Split('-')[0]);
                var monthOfBirth = int.Parse(splitedString[4].Split('-')[1]);
                var dayOfBirth = int.Parse(splitedString[4].Split('-')[2]);
                person.BirthDate = new DateTime(yearOfBirth, monthOfBirth, dayOfBirth);
                paper.Author = person;
                ResearchTeamPaperList.Add(paper);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

    }
}
