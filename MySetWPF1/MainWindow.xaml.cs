using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using MySetProject;
using MySetWpf;
using System.Linq;

namespace WpfSet;

public partial class MainWindow : Window
{
    MySet<Student> _men = new MySet<Student>();
    MySet<Student> _women = new MySet<Student>();
    MySet<Student> _reading = new MySet<Student>();
    MySet<Student> _writing = new MySet<Student>();
    MySet<Student> _arithmetic = new MySet<Student>();

    Dictionary<string, MySet<Student>> allSets = new Dictionary<string, MySet<Student>>();

    public MainWindow()
    {
        Student James = new Student(1, "James", Gender.Male);
        Student Robert = new Student(2, "Robert", Gender.Male);
        Student John = new Student(3, "John", Gender.Male);
        Student Mark = new Student(4, "Mark", Gender.Male);
        Student otherMark = new Student(5, "Mark", Gender.Male);
        _men.AddRange(new Student[] { James, Robert, John, Mark, otherMark });

        Student Liz = new Student(6, "Elizabeth", Gender.Female);
        Student Amy = new Student(7, "Amy", Gender.Female);
        Student Eve = new Student(8, "Evelyn", Gender.Female);
        _women.AddRange(new Student[] { Liz, Amy, Eve });

        _reading.AddRange(new Student[] { James, Robert, Liz });
        _writing.AddRange(new Student[] { Robert, Mark, Eve, Amy, Liz });
        _arithmetic.AddRange(new Student[] { John, Mark, otherMark, Amy });


        allSets.Add("Men", _men);
        allSets.Add("Women", _women);
        allSets.Add("Reading", _reading);
        allSets.Add("Writing", _writing);
        allSets.Add("Arithmetic", _arithmetic);

        InitializeComponent();

    }

    public void Window_Loaded(object sender, RoutedEventArgs e)
    {
        foreach (string name in allSets.Keys)
        {
            leftSet.Items.Add(name);
            rightSet.Items.Add(name);

        }

        operation.Items.Add("UNION");
        operation.Items.Add("INTESECTION");
        operation.Items.Add("DIFFERENCE");
        operation.Items.Add("SYMETRIC DIFF");

    }

    private void leftSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        leftMembers.Items.Clear();

        if (e.AddedItems.Count > 0)
        {
            DisplaySetData(GetByName(e.AddedItems[0].ToString()), leftMembers);
        }

    }

    private void rightSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        rightMembers.Items.Clear();
        if (e.AddedItems.Count > 0)
        {
            DisplaySetData(GetByName(e.AddedItems[0].ToString()), rightMembers);
        }
    }

    MySet<Student> GetByName(string name)
    {
        return allSets[name];
    }

    void DisplaySetData(MySet<Student> set, ListBox list)
    {
        list.Items.Clear();

        foreach (Student s in set.OrderBy(student => student.StudentId))
        {
            list.Items.Add(string.Format("{0}: {1}", s.StudentId, s.Name));
        }
    }

    private void evaluateButton_Click(object sender, RoutedEventArgs e)
    {
        resultSet.Items.Clear();
        if (operation.SelectedItem != null)
        {
            MySet<Student> results = UpdateResultSet(GetByName(leftSet.SelectedItem.ToString()),
                GetByName(rightSet.SelectedItem.ToString()),
                operation.SelectedItem.ToString());
            DisplaySetData(results, resultSet);
        }
    }

    private MySet<Student> UpdateResultSet(MySet<Student> left, MySet<Student> right, string op)
    {
        switch (op)
        {
            case "UNION":
                return left.Union(right);
            case "INTESECTION":
                return left.Intersection(right);
            case "DIFFERENCE":
                return left.Difference(right);
            case "SYMETRIC DIFF":
                return left.SymmetricDifference(right);
            default:
                MySet<Student> resultSet = new MySet<Student>();
                resultSet.Add(new Student(-1, "Error", Gender.Unknown));
                return resultSet;
        }

    }
}