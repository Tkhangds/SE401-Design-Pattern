using System;

public interface IControlSystem
{
    void Control(string plantType);
}

public class ManualControl : IControlSystem
{
    public void Control(string plantType)
    {
        Console.WriteLine($"Đang điều khiển thủ công việc tưới cho {plantType}");
    }
}

public class AutomaticControl : IControlSystem
{
    public void Control(string plantType)
    {
        Console.WriteLine($"Đang điều khiển tự động việc tưới cho {plantType} dựa trên độ ẩm của đất");
    }
}

public abstract class IrrigationSystem
{
    protected IControlSystem _controlSystem;
    
    public IrrigationSystem(IControlSystem controlSystem)
    {
        _controlSystem = controlSystem;
    }
    
    public void SetControlSystem(IControlSystem controlSystem)
    {
        _controlSystem = controlSystem;
    }
    
    public abstract void WaterPlants(string plantType);
}

public class DripIrrigation : IrrigationSystem
{
    public DripIrrigation(IControlSystem controlSystem) : base(controlSystem)
    {
    }

    public override void WaterPlants(string plantType)
    {
        Console.WriteLine($"Sử dụng hệ thống tưới nhỏ giọt cho {plantType}");
        _controlSystem.Control(plantType);
    }
}

public class SprinklerIrrigation : IrrigationSystem
{
    public SprinklerIrrigation(IControlSystem controlSystem) : base(controlSystem)
    {
    }

    public override void WaterPlants(string plantType)
    {
        Console.WriteLine($"Sử dụng hệ thống tưới phun sương cho {plantType}");
        _controlSystem.Control(plantType);
    }
}

public class ManualIrrigation : IrrigationSystem
{
    public ManualIrrigation(IControlSystem controlSystem) : base(controlSystem)
    {
    }

    public override void WaterPlants(string plantType)
    {
        Console.WriteLine($"Sử dụng hệ thống tưới bằng tay cho {plantType}");
        _controlSystem.Control(plantType);
    }
}

public class IrrigationManagementSystem
{
    public static void Main(string[] args)
    {
        IControlSystem manualControl = new ManualControl();
        IControlSystem automaticControl = new AutomaticControl();
        
        Console.WriteLine("=== Hệ thống tưới nhỏ giọt ===");
        IrrigationSystem dripWithManual = new DripIrrigation(manualControl);
        dripWithManual.WaterPlants("cà chua");

        Console.WriteLine("\n=== Hệ thống tưới nhỏ giọt với điều khiển tự động ===");
        IrrigationSystem dripWithAutomatic = new DripIrrigation(automaticControl);
        dripWithAutomatic.WaterPlants("dâu tây");

        Console.WriteLine("\n=== Hệ thống tưới phun sương với điều khiển thủ công ===");
        IrrigationSystem sprinklerWithManual = new SprinklerIrrigation(manualControl);
        sprinklerWithManual.WaterPlants("hoa hồng");

        Console.WriteLine("\n=== Hệ thống tưới phun sương với điều khiển tự động ===");
        IrrigationSystem sprinklerWithAutomatic = new SprinklerIrrigation(automaticControl);
        sprinklerWithAutomatic.WaterPlants("cỏ sân vườn");

        Console.WriteLine("\n=== Hệ thống tưới bằng tay với điều khiển thủ công ===");
        IrrigationSystem manualWithManual = new ManualIrrigation(manualControl);
        manualWithManual.WaterPlants("cây cảnh");

        Console.WriteLine("\n=== Thay đổi hệ thống điều khiển ===");
        Console.WriteLine("Chuyển từ điều khiển thủ công sang tự động:");
        manualWithManual.SetControlSystem(automaticControl);
        manualWithManual.WaterPlants("cây cảnh");
    }
}