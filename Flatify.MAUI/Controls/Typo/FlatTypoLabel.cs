using Flatify.MAUI.Enums;

namespace Flatify.MAUI.Controls.Typo;

public class FlatTypoLabel : Label
{
	public static readonly BindableProperty ColorProperty = BindableProperty.Create(
		propertyName: nameof(Color),
		returnType: typeof(FlatColor),
		declaringType: typeof(FlatTypoLabel),
		defaultValue: FlatColor.Default,
		propertyChanged: OnColorChanged);
	
	public static readonly BindableProperty TypeProperty = BindableProperty.Create(
		propertyName: nameof(Type),
		returnType: typeof(FlatTypoType),
		declaringType: typeof(FlatTypoLabel),
		defaultValue: FlatTypoType.Body1,
		propertyChanged: OnTypeChanged);

	public FlatColor Color
	{
		get => (FlatColor)GetValue(ColorProperty);
		set => SetValue(ColorProperty, value);
	}
	
	public FlatTypoType Type
	{
		get => (FlatTypoType)GetValue(TypeProperty);
		set => SetValue(TypeProperty, value);
	}
	
	public FlatTypoLabel() : base()
	{
		StyleClass = RebuildStyleClasses(Type, Color);
	}

	private static void OnColorChanged(BindableObject bindable, object oldValue, object newValue)
	{
		if (bindable is FlatTypoLabel label)
			label.StyleClass = RebuildStyleClasses(label.Type, (FlatColor)newValue);
	}

	private static void OnTypeChanged(BindableObject bindable, object oldValue, object newValue)
	{
		if (bindable is FlatTypoLabel label)
			label.StyleClass = RebuildStyleClasses((FlatTypoType)newValue, label.Color);
	}

	private static string[] RebuildStyleClasses(FlatTypoType labelType, FlatColor newValue)
	{
		var styleClasses = new List<string>();
		styleClasses.Add($"flat-typo-{labelType.ToString().ToLower()}");
		styleClasses.Add($"flat-typo-{newValue.ToString().ToLower()}");
		return styleClasses.ToArray();
	}
}