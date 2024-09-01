using BlazorCVA.Demo.Enums;

namespace BlazorCVA.Demo.Components.Pages;

public partial class BasicDemo
{
    private string? button1Classes;
    private string? button2Classes;

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
                    { "large", "btn-lg" }
                }
            }
        },
        DefaultVariants = new()
        {
            { Variant.Intent, Intent.Primary },
            { Variant.Size, "small" }
        }
    };

    protected override void OnInitialized()
    {
        button1Classes = variantManager.GetClass(); 
        button2Classes = variantManager.GetClass(new() { { Variant.Intent, Intent.Secondary }, { Variant.Size, "large" } });
    }



    private readonly string styleExampleCode =
@"<style>
    .btn {
        cursor: pointer;
        font-size: 1rem;
        padding: 0.5rem 1rem;
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
</style>";
    private readonly string razorExampleCode =
@"<button class=""@button1Classes"">Primary Small Button</button>
<button class=""@button2Classes"">Secondary Large Button</button>";
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

    private string? button1Classes;
    private string? button2Classes;

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
                    { ""large"", ""btn-lg"" }
                }
            }
        },
        DefaultVariants = new()
        {
            { Variant.Intent, Intent.Primary },
            { Variant.Size, ""small"" }
        }
    };

    protected override void OnInitialized()
    {
        button1Classes = variantManager.GetClass(); 
        button2Classes = variantManager.GetClass(new() { { Variant.Intent, Intent.Secondary }, { Variant.Size, ""large"" } });
    }
}";
}
