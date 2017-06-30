using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using testapp.Services;

namespace testapp.Models
{
    class Medicines
    {
        private static Medicines instance;

        public List<Medicine> medicines { get; set; }

        public static Medicines Instance
        {
            get
            {
                if (instance == null)
                {
                    String json = SignUpService.Instance.getMedicines();
                    instance = new Medicines(json);
                }
                return instance;
            }
        }

        public Medicines(String json)
        {
            medicines = new List<Medicine>();
            dynamic results = JsonConvert.DeserializeObject<dynamic>(json);

            foreach (dynamic m in results)
            {
                Medicine medicine = new Medicine(m);
                medicines.Add(medicine);
            }

        }

        public List<Medicine> GetMedicinesByMedicinetype(String medicinetype)
        {
            List<Medicine> medicines = new List<Medicine>();

            foreach (Medicine m in this.medicines)
            {
                if (m.medicinetype == medicinetype)
                {
                    medicines.Add(m);
                }
            }

            return medicines;
        }
    }
}
