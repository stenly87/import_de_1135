namespace ConsoleApp51
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ModelContext modelContext = new ModelContext();
            /*string file = @"\\192.168.100.32\кабинеты\4\ДЭ Программные решения для бизнеса\2020\09_1.9_1\Сессия 1\client_import.csv";
            var rows = File.ReadAllLines(file);
            for (int i = 1; i < rows.Length; i++)
            {
                //Голубев;Иосиф;Тимофеевич;м;7(78)972-73-11;Клиенты\m18.jpg;1982-05-06;smcnabb@att.net;2018-08-18
                var cols = rows[i].Split(';');  
                Client client = new Client();
                client.LastName = cols[0];
                client.FirstName = cols[1];
                client.Patronymic = cols[2];
                client.GenderCode = cols[3];
                client.Phone = cols[4];
                client.PhotoPath = cols[5];
                client.Birthday = DateOnly.Parse(cols[6]);
                client.Email = cols[7];
                client.RegistrationDate = DateTime.Parse(cols[8]);
                modelContext.Clients.Add(client);
            }
            modelContext.SaveChanges();
            */
            /*
            string file = @"\\192.168.100.32\кабинеты\4\ДЭ Программные решения для бизнеса\2020\09_1.9_1\Сессия 1\service_a_import.txt";
            //Замена сальника привода, 570 мин., 3820, 15%
            var rows = File.ReadAllLines(file);
            for (int i = 1; i < rows.Length; i++)
            {
                var cols = rows[i].Split(',');
                Service service = new Service();
                service.Title = cols[0];
                var sec = cols[1].Trim().Split();
                service.DurationInSeconds = int.Parse(sec[0]);
                if (sec[1] == "мин.")
                    service.DurationInSeconds *= 60;
                else if (sec[1] == "час.")
                    service.DurationInSeconds *= 3600;
                service.Cost = int.Parse(cols[2]);

                if (cols[3].EndsWith('%'))
                {
                    service.Discount = int.Parse(cols[3].Replace("%", "")) 
                        / 100.0;
                }

                modelContext.Services.Add(service);
            }
            modelContext.SaveChanges();*/

            string file = @"\\192.168.100.32\кабинеты\4\ДЭ Программные решения для бизнеса\2020\09_1.9_1\Сессия 1\clientservice_a_import.csv";
            var rows = File.ReadAllLines(file);
            for (int i = 1; i < rows.Length; i++)
            {//Горбачёва,2019-06-21 14:49:59,Развал-схождение
                var cols = rows[i].Split(',');
                var client = modelContext.Clients.FirstOrDefault(s=>s.LastName == cols[0]);
                var service = modelContext.Services.FirstOrDefault(s => s.Title == cols[2]);

                if (client == null || service == null)
                {
                }

                ClientService clientService = new ClientService();
                clientService.ClientId = client.Id;
                clientService.ServiceId = service.Id;
                clientService.StartTime = DateTime.Parse(cols[1]);

                modelContext.ClientServices.Add(clientService);
            }
            modelContext.SaveChanges();

        }
    }
}
