﻿using Rationals;
using System;
using System.Globalization;
using System.Windows;

namespace WpfApp;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    /// <summary>
    ///     Ctor.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        ButtonPlus.Click += ButtonPlus_Click;
        ButtonDivision.Click += ButtonDivision_Click;
        ButtonMinus.Click += ButtonMinus_Click;
        ButtonMultiplication.Click += ButtonMultiplication_Click;
    }

    private void ButtonMultiplication_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            UpData(out var rationalOne, out var rationalTwo);
            LoadData(rationalOne * rationalTwo);
        }
        catch (DivideByZeroException)
        {
            MessageBox.Show("Нельзя делить на ноль!");
        }
        catch (OverflowException)
        {
            MessageBox.Show("Число слишком большое или очень маленькое!");
        }
    }

    private void ButtonMinus_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            UpData(out var rationalOne, out var rationalTwo);
            LoadData(rationalOne - rationalTwo);
        }
        catch (DivideByZeroException)
        {
            MessageBox.Show("Нельзя делить на ноль!");
        }
        catch (OverflowException)
        {
            MessageBox.Show("Число слишком большое или очень маленькое!");
        }
    }

    private void ButtonDivision_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            UpData(out var rationalOne, out var rationalTwo);
            LoadData(rationalOne / rationalTwo);
        }
        catch (DivideByZeroException)
        {
            MessageBox.Show("Нельзя делить на ноль!");
        }
        catch (OverflowException)
        {
            MessageBox.Show("Число слишком большое или очень маленькое!");
        }
    }

    private void ButtonPlus_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            UpData(out var rationalOne, out var rationalTwo);
            LoadData(rationalOne + rationalTwo);
        }
        catch (DivideByZeroException)
        {
            MessageBox.Show("Нельзя делить на ноль!");
        }
        catch (OverflowException)
        {
            MessageBox.Show("Число слишком большое или очень маленькое!");
        }
    }

    /// <summary>
    ///     Отображение данных на форме
    /// </summary>
    /// <param name="rational">Результат который нужно отобразить</param>
    private void LoadData(Rational rational)
    {
        TextBoxOrd.Text = rational.AsDouble().ToString(CultureInfo.InvariantCulture);
        TextBoxDecimalsForm.Text = rational.ToString();
    }

    /// <summary>
    ///     Запись в переменные <paramref name="rationalOne"/> и <paramref name="rationalTwo"/>
    ///     Получая переменные заполняются из формы
    /// </summary>
    /// <param name="rationalOne">Первое число</param>
    /// <param name="rationalTwo">Второе число</param>
    private void UpData(out Rational rationalOne, out Rational rationalTwo)
    {
        rationalOne = AssemblyNumber(TextBoxInputInteger1.Text, TextBoxInputNumerator1.Text, TextBoxInputDenominator1.Text);
        rationalTwo = AssemblyNumber(TextBoxInputInteger2.Text, TextBoxInputNumerator2.Text, TextBoxInputDenominator2.Text);
    }

    /// <summary>
    ///     Сборка рационального числа из целой части, числителя дроби и знаменателя.
    /// </summary>
    /// <param name="integerPart">Целая часть дроби.</param>
    /// <param name="numerator">Числитель дроби.</param>
    /// <param name="denominator">Знаменатель дроби.</param>
    /// <returns>Рациональное число.</returns>
    private static Rational AssemblyNumber(string integerPart, string numerator, string denominator)
    {
        Rational integer = new(integerPart);
        Rational fractional = new(numerator + '/' + denominator);
        return integer + fractional;
    }
}