namespace Flatify.MAUI.Controls.Forms;

public interface IFormField
{
    public bool IsValid { get; set; }
    
    public void Validate();
}