using System;
using Gtk;

class Program
{
    static void Main()
    {
        Application.Init();

        // Creates a new window with the title 'Caesar Cipher'         
        var window = new Window("Caesar Cipher")
        {
            DefaultSize = new Gdk.Size(700, 200)
        };

        // Create a box to hold the widgets
        var box = new Box(Orientation.Vertical, 5);

        // Text entry field for the text to be ciphered
        var inputText = new Entry { PlaceholderText = "Enter text" };
        box.PackStart(inputText, false, false, 5);

        // Text entry field for the shift value to vbe used
        var shiftInput = new Entry { PlaceholderText = "Enter shift (e.g., -5 or +5)" };
        box.PackStart(shiftInput, false, false, 5);

        // Generate button
        var generateButton = new Button("Generate");
        box.PackStart(generateButton, false, false, 5);

        // Entry field for the output so it will be easily copyable
        var outputEntry = new Entry
        {
            IsEditable = false,
            CanFocus = true,
            Text = "Output will appear here..."

        };
        box.PackStart(outputEntry, false, false, 5);

        // Add the box to the window
        window.Add(box);

        // Generate buttons click event thingy
        generateButton.Clicked += (sender, e) =>
        {
            string text = inputText.Text;
            if (int.TryParse(shiftInput.Text, out int shift))
            {
                string result = CaesarCipher(text, shift);
                outputEntry.Text = result;
            }
            else
            {
                outputEntry.Text = "Please enter a valid integer for the shift.";
            }
        };

        window.DeleteEvent += (o, args) =>
        {
            Application.Quit();
        };

        // Shows the widgets
        window.ShowAll();

        Application.Run();
    }

    // Caesar cipher logic
    static string CaesarCipher(string text, int shift)
    {
        char[] buffer = text.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];

            
            if (char.IsLetter(letter))
            {
                char offset = char.IsUpper(letter) ? 'A' : 'a';
                letter = (char)(((letter - offset + shift + 26) % 26) + offset);
                buffer[i] = letter;
            }
            
            buffer[i] = letter;
        }
        return new string(buffer);
    }
}
