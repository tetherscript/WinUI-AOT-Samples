using CommunityToolkit.WinUI.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace AOTCombinedTests;

public sealed partial class AdvancedCollectionViewPage : Page
{
    public ObservableCollection<Employee>? EmployeeCollection { get; private set; }

    public AdvancedCollectionView? CollectionView { get; private set; }

    [DynamicDependency(
        DynamicallyAccessedMemberTypes.PublicProperties
        | DynamicallyAccessedMemberTypes.PublicConstructors,
        typeof(Employee))]
    public AdvancedCollectionViewPage()
    {
        this.InitializeComponent();
        Setup();
    }

    [MemberNotNull(nameof(EmployeeCollection))]
    [MemberNotNull(nameof(CollectionView))]
    private void Setup()
    {
        // left list
        EmployeeCollection = new()
            {
                new() { Name = "Staff" },
                new() { Name = "42" },
                new() { Name = "Swan" },
                new() { Name = "Orchid" },
                new() { Name = "15" },
                new() { Name = "Flame" },
                new() { Name = "16" },
                new() { Name = "Arrow" },
                new() { Name = "Tempest" },
                new() { Name = "23" },
                new() { Name = "Pearl" },
                new() { Name = "Hydra" },
                new() { Name = "Lamp Post" },
                new() { Name = "4" },
                new() { Name = "Looking Glass" },
                new() { Name = "8" },
            };

        // right list
        AdvancedCollectionView acv = CreateAdvancedCollectionView(EmployeeCollection);

        acv.Filter = x => !int.TryParse(((Employee)x).Name, out _);
        acv.SortDescriptions.Add(new(nameof(Employee.Name), SortDirection.Ascending));

        CollectionView = acv;
    }

    [UnconditionalSuppressMessage(
    "Trimming",
    "IL2026:RequiresUnreferencedCode",
    Justification = "Employee metadata is preserved via DynamicDependency on the constructor.")]
    private AdvancedCollectionView CreateAdvancedCollectionView(ObservableCollection<Employee> list)
    {
        return new(list);
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(NewItemBox.Text))
        {
            EmployeeCollection?.Insert(0, new Employee { Name = NewItemBox.Text });
            NewItemBox.Text = "";
        }
    }

}

public partial class Employee
{
    public string? Name { get; set; }
}