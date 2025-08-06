namespace Event_Delegates
{
    /*
     1) Delegate (like a contact saved in your phone)
        Technicall Defination :-  
        A type-safe function pointer that can reference methods with a particular parameter list and return type.
        Simple definition:
        A delegate is like saving a method’s address, so you can call it later — just like saving someone’s number in your phone so you can call them when needed.

        ✅ Example in life:
        You save your friend's number (delegate).
        Later, you call them (invoke the delegate).
        You can call any friend who matches the same "calling format" (same method signature).
        So a delegate is a placeholder for any method that has a specific format (same input parameters and return type).

    2) Event (like a doorbell — others can listen, but only you can ring it)
        Technical Definition :- A wrapper around the delegate that provides controlled access, allowing only subscription and unsubscription (not direct invocation from outside the class).
        Simple definition:
        An event is like a doorbell that only the owner of the house can ring, but neighbors or friends can say,
        "Hey, let me know when the bell rings" (subscribe).

        ✅ Example in life:
        You install a doorbell (event).
        Your friends say, “Let me know when someone rings it” (subscribe to the event).
        Only you can press the bell (raise the event).
        When it's pressed, all subscribed friends are notified (their methods are called).
        So an event uses a delegate, but controls who can call (invoke) it — only the class that owns the event can raise it.
     */


    // 1. Define a delegate to match the event signature
    public delegate void OverheatEventHandler(float temperature);
    internal class Program
    {
        public static void Main()
        {
            // 12. Create publisher and subscriber instances
            TemperatureSensor sensor = new TemperatureSensor();
            CoolingSystem cooler = new CoolingSystem();
            AlarmSystem alarm = new AlarmSystem();

            // 13. Subscribe to the event
            sensor.Overheated += cooler.ActivateCooling;
            sensor.Overheated += alarm.TriggerAlarm;

            // 14. Simulate temperatures
            sensor.ReadTemperature(35);  // Normal temperature — no event
            sensor.ReadTemperature(42);  // High temperature — event triggered

            // 15. Unsubscribe one handler
            sensor.Overheated -= alarm.TriggerAlarm;

            // 16. Event will only trigger cooling system now
            sensor.ReadTemperature(45);

            // Generic delegate example
            GenericDelegate.GeneriDelegateExample();
        }
    }
    // 2. Publisher class
    public class TemperatureSensor
    {
        // 3. Declare an event using the delegate
        public event OverheatEventHandler Overheated;

        // 4. Method to simulate temperature change
        public void ReadTemperature(float currentTemp)
        {
            Console.WriteLine($"Current Temperature: {currentTemp}°C");
            // 5. Check if temperature is too high
            if (currentTemp > 40)
            {
                Console.WriteLine("Warning: Overheating detected!");
                // 6. Raise the event
                OnOverheated(currentTemp);
            }
        }

        // 7. Protected method to raise the event safely
        protected virtual void OnOverheated(float temp)
        {
            Overheated?.Invoke(temp); // 8. Only invoke if there are subscribers
        }
    }

    // 9. Subscriber class 1
    public class CoolingSystem
    {
        public void ActivateCooling(float temp)
        {
            Console.WriteLine($"[CoolingSystem] Activated cooling at {temp}°C.");
        }
    }

    // 10. Subscriber class 2
    public class AlarmSystem
    {
        public void TriggerAlarm(float temp)
        {
            Console.WriteLine($"[AlarmSystem] Alarm triggered! Temperature is {temp}°C.");
        }
    }
}
