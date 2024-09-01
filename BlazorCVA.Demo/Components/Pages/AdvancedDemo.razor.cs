using BlazorCVA.Demo.Enums;
using Microsoft.AspNetCore.Components;

namespace BlazorCVA.Demo.Components.Pages;

public partial class AdvancedDemo
{
    private string? buttonClasses;
    private Intent selectedIntent = Intent.Primary;
    private string selectedSize = "small";

    private VariantManager<Variant> variantManager = new VariantManager<Variant>()
    {
        BaseClasses = ["btn"],
        Variants =
        {
            {
                Variant.Intent, new()
                {
                    { Intent.Primary, "btn-primary" },
                    { Intent.Secondary, "btn-secondary" }
                }
            },
            {
                Variant.Size, new()
                {
                    { "small", "btn-sm" },
                    { "large", "btn-lg" },
                    { "medium", "btn-md" }
                }
            }
        },
        CompoundVariants =
            [
                new()
            {
                Conditions =
                [
                    (Variant.Size, "large"),
                    (Variant.Intent, Intent.Primary)
                ],
                Class = "btn-primary-lg"
            },
            new()
            {
                Conditions =
                [
                    (Variant.Size, "small"),
                    (Variant.Intent, value => value is Intent.Secondary)
                ],
                Class = "btn-secondary-sm"
            }
            ],
        DefaultVariants = new()
        {
            { Variant.Intent, Intent.Primary },
            { Variant.Size, "small" }
        }
    };

    protected override void OnInitialized()
    {
        UpdateButtonClasses();
    }

    private void OnIntentChanged(ChangeEventArgs e)
    {
        selectedIntent = Enum.Parse<Intent>(e.Value?.ToString() ?? "Primary");
        UpdateButtonClasses();
    }

    private void OnSizeChanged(ChangeEventArgs e)
    {
        selectedSize = e.Value?.ToString() ?? "small";
        UpdateButtonClasses();
    }

    private void UpdateButtonClasses()
    {
        buttonClasses = variantManager.GetClass(new()
        {
            { Variant.Intent, selectedIntent },
            { Variant.Size, selectedSize }
        });
    }



    private readonly string styleExampleCode =
@"<style>
    .btn {
        cursor: pointer;
        font-size: 1rem;
        padding: 0.5rem 1rem;
        transition: all 0.3s;
        border-radius: 0.25rem;
        border: 1px solid transparent;
    }

    .btn-primary {
        color: #fff;
        border-color: #007bff;
        background-color: #007bff;
    }

    .btn-primary:hover {
        border-color: #004085;
        background-color: #0056b3;
    }

    .btn-secondary {
        color: #fff;
        border-color: #6c757d;
        background-color: #6c757d;
    }

    .btn-secondary:hover {
        border-color: #545b62;
        background-color: #5a6268;
    }

    .btn-sm {
        font-size: 0.875rem;
        padding: 0.25rem 0.5rem;
    }

    .btn-md {
        font-size: 1rem;
        padding: 0.5rem 1rem;
    }

    .btn-lg {
        font-size: 1.25rem;
        padding: 0.75rem 1.5rem;
    }

    .btn-primary-lg {
        border-color: #0062cc;
        background-color: #0069d9;
    }

    .btn-secondary-sm {
        border-color: #545b62;
        background-color: #5a6268;
    }
</style>";
    private readonly string razorExampleCode =
@"<label for=""intentSelect"">Select Intent:</label>
<select id=""intentSelect"" @onchange=""OnIntentChanged"">
    @foreach (Intent intent in Enum.GetValues(typeof(Intent)))
    {
        <option value=""@intent"">@intent</option>
    }
</select>

<label for=""sizeSelect"">Select Size:</label>
<select id=""sizeSelect"" @onchange=""OnSizeChanged"">
    <option value=""small"">Small</option>
    <option value=""medium"">Medium</option>
    <option value=""large"">Large</option>
</select>

<button class=""@buttonClasses"">Button</button>";
    private readonly string csharpExampleCode =
@"@code {
    public enum Variant
    {
        Intent,
        Size
    }

    public enum Intent
    {
        Primary,
        Secondary
    }

    private string? buttonClasses;
    private Intent selectedIntent = Intent.Primary;
    private string selectedSize = ""small"";

    private VariantManager<Variant> variantManager = new VariantManager<Variant>()
    {
        BaseClasses = [""btn""],
        Variants =
        {
            {
                Variant.Intent, new()
                {
                    { Intent.Primary, ""btn-primary"" },
                    { Intent.Secondary, ""btn-secondary"" }
                }
            },
            {
                Variant.Size, new()
                {
                    { ""small"", ""btn-sm"" },
                    { ""large"", ""btn-lg"" },
                    { ""medium"", ""btn-md"" }
                }
            }
        },
        CompoundVariants =
            [
                new()
            {
                Conditions =
                [
                    (Variant.Size, ""large""),
                    (Variant.Intent, Intent.Primary)
                ],
                Class = ""btn-primary-lg""
            },
            new()
            {
                Conditions =
                [
                    (Variant.Size, ""small""),
                    (Variant.Intent, value => value is Intent.Secondary)
                ],
                Class = ""btn-secondary-sm""
            }
            ],
        DefaultVariants = new()
        {
            { Variant.Intent, Intent.Primary },
            { Variant.Size, ""small"" }
        }
    };

    protected override void OnInitialized()
    {
        UpdateButtonClasses();
    }

    private void OnIntentChanged(ChangeEventArgs e)
    {
        selectedIntent = Enum.Parse<Intent>(e.Value?.ToString() ?? ""Primary"");
        UpdateButtonClasses();
    }

    private void OnSizeChanged(ChangeEventArgs e)
    {
        selectedSize = e.Value?.ToString() ?? ""small"";
        UpdateButtonClasses();
    }

    private void UpdateButtonClasses()
    {
        buttonClasses = variantManager.GetClass(new()
        {
            { Variant.Intent, selectedIntent },
            { Variant.Size, selectedSize }
        });
    }
}";
}