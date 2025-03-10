namespace singleton_sample;

class PatientProfile
{
    public string Id { get; set; }
    public string Name { get; set; }
} 

class PatientProfileManager
{
    private static PatientProfileManager _instance;
    private readonly List<PatientProfile> _profiles;

    private PatientProfileManager()
    {
        _profiles = new List<PatientProfile>();
    }

    public static PatientProfileManager GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PatientProfileManager();
            }
            return _instance;
        }
    }
    
    // Add a new patient
    public void AddProfile(PatientProfile patient)
    {
        if (!_profiles.Exists(e => e.Id == patient.Id))
        {
            _profiles.Add(patient); 
            Console.WriteLine($"Added: {patient}");
        }
        else
        {
            Console.WriteLine($"Patient with ID {patient.Id} already exists.");
        }
    }
    // Retrieve a patient profile
    public void RetrieveProfile(string id)
    {
        if (_profiles.Exists(e => e.Id == id))
        {
            Console.WriteLine($"Retrieved: {_profiles.Find(e => e.Id == id).Name}");
        }
        else
        {
            Console.WriteLine($"Patient with ID {id} not found.");
        }
    }
    // Update an existing patient profile
    public void UpdateProfile(string id, string newName)
    {
        PatientProfile patient = _profiles.Find(e => e.Id == id);
        
        if (patient != null)
        {
            patient.Name = newName;
            Console.WriteLine($"Updated: {patient}");
        }
        else
        {
            Console.WriteLine($"Patient with ID {id} not found.");
        }
    }
    // Remove a patient profile
    public void RemoveProfile(string id)
    {
        PatientProfile patient = _profiles.Find(e => e.Id == id);
        
        if (patient != null)
        {
            _profiles.Remove(patient);
            Console.WriteLine($"Removed: {patient}");
        }
        else
        {
            Console.WriteLine($"Patient with ID {id} not found.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        PatientProfileManager nurse = PatientProfileManager.GetInstance;
        PatientProfileManager doctor = PatientProfileManager.GetInstance;
        
        PatientProfile patient1 = new PatientProfile { Id = "1", Name = "Alice" };
        
        nurse.AddProfile(patient1);
        
        Console.WriteLine("Doctor retrieves patient profile:");
        doctor.RetrieveProfile("1");
        
        Console.WriteLine("Nurse retrieves patient profile:");
        nurse.RetrieveProfile("1");
        
    }
}