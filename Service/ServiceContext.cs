using Service.Entites;
using Service.Requests;
using Service.Responses;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;

namespace Service
{
    [ServiceBehavior]
    public class ServiceContext : IServiceContract
    {
        Context db;

        public AutorizationResponse Autorization(AutorizationRequest autorization)
        {
            using (Context db = new Context())
            {
                var result = db.users.Where(p => p.login == autorization.login).FirstOrDefault();
                if (result == null)
                {
                    return new AutorizationResponse { errMessage = "Такой пользователь с данным логином не найден!", error = true };
                }
                result = db.users.Where(p => p.password == autorization.password).FirstOrDefault();
                if (result == null)
                {
                    return new AutorizationResponse { errMessage = "Введен неверный пароль!", error = true };
                }
                return new AutorizationResponse { };
            }
        }

        public string Recording(RecordingRequest recording)
        {
            using (Context db = new Context())
            {
                var result = db.masters.Where(p => p.record.dateTime == recording.dateTime && p.name == recording.master).FirstOrDefault();
                if (result != null)
                {
                    return "Это время уже занято!";
                }
                Record record = new Record() { dateTime = recording.dateTime };
                Master master = new Master { name = recording.master, record = record };
                db.masters.Add(master);
                db.SaveChanges();
                return "Запись добавлена!";
            }
        }

        public RegistrationResponse Registration(RegistrationRequest registration)
        {
            using (Context db = new Context())
            {
                var result = db.users.Where(p => p.login == registration.login).FirstOrDefault();
                if (result != null)
                {
                    return new RegistrationResponse { errMessage = "Пользователь с таким логином уже имеется!", error = true };
                }
                User user = new User { login = registration.login, name = registration.name, surname = registration.surname, password = registration.password };
                db.users.Add(user);
                db.SaveChanges();
                return new RegistrationResponse { errMessage = "Регистрация прошла успешно!", error = false };
            }
        }
        //public void Db(Service.Context con)
        //{
        //    db = con;
        //}
    }
}
