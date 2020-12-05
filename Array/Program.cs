using System;

namespace Array
{
    class Program
    {
        #region Fields
        static double[,] array = { { 1.0 } };

        static int numRows = 0, numColumns = 0;

        static int numNegativeEl = 0, numPositiveEl = 0;
        #endregion

        #region Main
        static void Main(string[] args)
        {
            Start();
        }
        #endregion

        ///<summary>
        ///Greeting output.
        ///</summary>
        #region ShowGreeting
        static void ShowGreeting()
        {
            // Greeting output
            // Output of the inscription approximately to the middle of the window
            Console.Write("\t\t");

            var greeting = "Hello! Welcome to the program for processing of Arrays.";

            // Change font and background color
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(greeting);

            // Return color and background
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine();
        }
        #endregion

        ///<summary>
        /// Display the main menu.
        ///</summary>
        #region Menu
        static void Menu()
        {
            Console.Write("\t");

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("MENU:");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine();

            Console.WriteLine("press 1 for creation of a new matrix;");
            Console.WriteLine("press 2 for search of quantity positive/negative numbers in a matrix;");
            Console.WriteLine("press 3 for sorting of elements;");
            Console.WriteLine("press 4 for inversion of elements;");
            Console.WriteLine("press 5 for program information;");
            Console.WriteLine("press 6 to exit the program.");

            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("select the required action: ");

            Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion

        ///<summary>
        /// Main menu number input.
        ///</summary>
        #region EnterNumberMenu
        static int EnterNumberMenu()
        {
            var numberMenu = 0;

            // Cycle until one of the menu item numbers is entered
            while (true)
            {
                // Entering the action number from the menu
                try
                {
                    numberMenu = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                var condition = numberMenu > 0 && numberMenu < 7;

                // Ccheck for correspondence of the number from the menu to the entered number
                if (condition)
                {
                    break;
                }
                else
                {
                    var message = "\nenter a number from 1 to 6: ";

                    Console.Clear();

                    Menu();

                    Console.Write(message);

                    continue;
                }
            }

            return numberMenu;
        }
        #endregion

        ///<summary>
        /// Setting the number of array rows.
        ///</summary>
        #region ReadNumRows
        static void ReadNumRows()
        {
            while (true)
            {
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write("Enter the number rows: ");
                    
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        numRows = int.Parse(Console.ReadLine());

                        if (numRows <= 0)
                            throw new InvalidOperationException();

                        if (numRows > 100)
                            throw new OutOfMemoryException();

                        Console.ForegroundColor = ConsoleColor.Gray;

                        break;
                    }
                    catch (OutOfMemoryException ex)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine(ex.Message + "\nEnter value > 0 and < 100.");

                        continue;
                    }
                catch (OverflowException ex)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine(ex.Message);

                        continue;
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine(ex.Message + "\nEnter value > 0.");

                        continue;
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine(ex.Message + "\nEnter an integer value, for example 7.");

                        continue;
                    }
             }
        }
        #endregion

        ///<summary>
        /// Setting the number of array columns.
        ///</summary>
        #region ReadNumColumns
        static void ReadNumColumns()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write("Enter the number columns: ");

                try
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    numColumns = int.Parse(Console.ReadLine());

                    if (numColumns <= 0)
                        throw new InvalidOperationException();

                    if (numColumns > 100)
                        throw new OutOfMemoryException();

                    Console.ForegroundColor = ConsoleColor.Gray;

                    break;
                }
                catch (OutOfMemoryException ex)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(ex.Message + "\nEnter value > 0 and < 100.");

                    continue;
                }
                catch (OverflowException ex)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(ex.Message);

                    continue;
                }
                catch (InvalidOperationException ex)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(ex.Message + "\nEnter value > 0.");

                    continue;
                }
                catch (Exception ex)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(ex.Message + "\nEnter an integer value, for example 7.");

                    continue;
                }
            }
        }
        #endregion

        ///<summary>
        /// Entering an array element from the keyboard.
        ///</summary>
        #region EnterElArray
        static void EnterElArray()
        {
            Console.WriteLine($"Enter {numRows * numColumns} array elements: ");

            for (var i = 0; i < numRows; i++)
            {
                for (var j = 0; j < numColumns; j++)
                {
                    while (true)
                    {
                        try
                        {
                            Console.Write($"{i * numColumns + j + 1}. element - array[{i}, {j}]: ");

                            Console.ForegroundColor = ConsoleColor.Red;

                            array[i, j] = double.Parse(Console.ReadLine());

                            Console.ForegroundColor = ConsoleColor.Gray;

                            break;
                        }
                        catch (OverflowException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;

                            Console.Clear();

                            Console.WriteLine(ex.Message);

                            continue;
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;

                            Console.Clear();

                            Console.WriteLine(ex.Message + "\nEnter an integer or real value, for example 7 or 3,14.");

                            continue;
                        }
                    }
                }
            }
        }
        #endregion

        ///<summary>
        /// Display the invert menu.
        ///</summary>
        #region InverceMenu
        static void InverceMenu()
        {
            int i;

            for (i = 0; i < numRows; i++)
            {
                Console.WriteLine($"{i+1} for line number {i};");
            }

            Console.WriteLine($"{i + 1} for all line array.");

            Console.WriteLine($"{i + 2} for all array.");

            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("select the required action: ");

            Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion

        ///<summary>
        /// Invert any string of an array.
        ///</summary>
        #region InvertRowArray
        static void InvertRowArray(int numInvertRow)
        {
            double temp;

            for (int i = 0, j = numColumns - 1; i < numColumns / 2; i++, j--)
            {
                temp = array[numInvertRow, i];

                array[numInvertRow, i] = array[numInvertRow, j];

                array[numInvertRow, j] = temp;
            }
        }
        #endregion

        ///<summary>
        /// Invert all rows of an array.
        ///</summary>
        #region InvertAllLineArray
        static void InvertAllLineArray()
        {
            double temp;

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0, k = numColumns - 1; j < numColumns / 2; j++, k--)
                {
                    temp = array[i, j];

                    array[i, j] = array[i, k];

                    array[i, k] = temp;
                }
            }
        }
        #endregion

        ///<summary>
        /// Display the invert menu number.
        ///</summary>
        #region EnterNumInvMenu
        static int EnterNumInvMenu()
        {
            int numInvMenu = 0;

            // Cycle until one of the menu item numbers is entered
            while (true)
            {
                // Entering the action number from the menu
                numInvMenu = int.Parse(Console.ReadLine());

                var condition = numInvMenu > 0 && numInvMenu <= numRows + 2;

                // Ccheck for correspondence of the number from the menu to the entered number
                if (condition)
                {
                    break;
                }
                else
                {
                    Console.Clear();

                    Console.WriteLine("Your original array:");

                    OutArray();

                    Console.WriteLine();

                    InverceMenu();

                    Console.Write($"\nenter a number from 1 to {numRows + 2}: ");

                    continue;
                }
            }

            return numInvMenu;
        }
        #endregion

        ///<summary>
        /// Inverting the entire array.
        ///</summary>
        #region InvertAllArray
        static void InvertAllArray()
        {
            int numOper = 0;

            double temp;

            for (int i = 0, k = numRows - 1; i < numRows; i++, k--)
                for (int j = 0, b = numColumns - 1; j < numColumns; j++, b--)
                {
                    if (numOper < (numRows * numColumns) / 2)
                    {
                        temp = array[i, j];

                        array[i, j] = array[k, b];

                        array[k, b] = temp;
                    }

                    numOper++;
                }
        }
        #endregion

        ///<summary>
        /// Array output.
        ///</summary>
        #region OutArray
        static void OutArray()
        {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine(" " + new string('-', numColumns * 16));

                Console.Write("|r\\c|");

                for (var i = 0; i < numColumns; i++)
                    Console.Write($"\t{i}\t|");

                Console.WriteLine("\n " + new string('-', numColumns * 16));

                for (var i = 0; i < numRows; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write($"| {i} |");

                    for (var j = 0; j < numColumns; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        if (array[i, j] > 1000)
                        {
                            Console.Write("\t{0:#.#E+00}\t", array[i, j]);
                        }
                        else if (array[i, j] < -1000)
                        {
                            Console.Write("\t{0:#.#E+00}", Math.Round(array[i, j], 1));
                        }
                        else
                        {
                            Console.Write($"\t{Math.Round(array[i, j], 4)}\t");
                        }
                        
                    }
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write("|");

                    Console.WriteLine();
                }

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine(" " + new string('-', numColumns * 16));

                Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion

        ///<summary>
        /// Displaying the number of positive and negative elements of an array.
        ///</summary>
        #region NegativePositive
        static void NegativePositive()
        {
            for (var i = 0; i < numRows; i++)
            {
                for (var j = 0; j < numColumns; j++)
                {
                    if (array[i, j] < 0)
                    {
                        numNegativeEl++;
                    }
                    else
                    {
                        numPositiveEl++;
                    }
                }
            }
        }
        #endregion

        ///<summary>
        /// Displaying information about the program.
        ///</summary>
        #region AboutProgram
        static void AboutProgram()
        {
            Console.WriteLine("Array processing program, version 1.0");
            Console.WriteLine();
            Console.WriteLine("Allows you to perform the following operations:");
            Console.WriteLine("- choice of matrix size;");
            Console.WriteLine("- manual input of array elements;");
            Console.WriteLine("- outputting the array to the console as a matrix;");
            Console.WriteLine("- finding the number of positive and negative matrix elements;");
            Console.WriteLine("- sorting array elements line by line and the whole array;");
            Console.WriteLine("- inversion of elements line by line and the whole array.");
            Console.WriteLine();
            Console.WriteLine("Developer - Yarmalkevich V.I.");

            Console.WriteLine();
        }
        #endregion

        ///<summary>
        /// Display sorting menu for direction selection.
        ///</summary>
        #region SmallSortMenu
        static void SmallSortMenu()
        {
            Console.WriteLine("press 1 to sort from smallest to largest;");
            Console.WriteLine("press 2 to sort from highest to lowest.");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("select the required action: ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion

        ///<summary>
        /// Enter the sort menu number to select the direction.
        ///</summary>
        #region EnterNumSmallSortMenu
        static int EnterNumSmallSortMenu()
        {
            int numSmallSortMenu = 0;

            // Cycle until one of the menu item numbers is entered
            while (true)
            {
                // Entering the action number from the menu
                try
                {
                    numSmallSortMenu = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               
                // Ccheck for correspondence of the number from the menu to the entered number
                if (numSmallSortMenu > 0 && numSmallSortMenu < 3)
                {
                    break;
                }
                else
                {
                    Console.Clear();

                    Console.WriteLine("Your original array:");

                    OutArray();

                    SmallSortMenu();

                    Console.Write("\nenter a number from 1 or 2: ");

                    continue;
                }
            }

            return numSmallSortMenu;
        }
        #endregion

        ///<summary>
        /// Display sort menu.
        ///</summary>
        #region SortMenu
        static void SortMenu()
        {
            Console.WriteLine("\nSelect item to sort");

            int i;
            for (i = 0; i < numRows; i++)
            {
                Console.WriteLine($"{i + 1} for line number {i};");
            }

            Console.WriteLine($"{i + 1} for all line array.");

            Console.WriteLine($"{i + 2} for all array.");

            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("select the required action: ");

            Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion

        ///<summary>
        /// Enter sort menu number.
        ///</summary>
        #region EnterNumSorMenu
        static int EnterNumSorMenu()
        {
            int numSorMenu = 0;

            // Cycle until one of the menu item numbers is entered
            while (true)
            {
                // Entering the action number from the menu
                try
                {
                    numSorMenu = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
 
                var condition = numSorMenu > 0 && numSorMenu <= numRows + 2;

                // Ccheck for correspondence of the number from the menu to the entered number
                if (condition)
                {
                    break;
                }
                else
                {
                    Console.Clear();

                    Console.WriteLine("Your original array:");

                    OutArray();

                    Console.WriteLine();

                    SortMenu();

                    Console.Write($"\nenter a number from 1 to {numRows + 2}: ");

                    continue;
                }
            }

            return numSorMenu;
        }
        #endregion

        ///<summary>
        /// Sorting any row of an array from smallest to largest.
        ///</summary>
        #region SortRowArrayMinMax
        static void SortRowArrayMinMax(int numSortRow)
        {
            double temp;

            for (var i = 0; i < numColumns; i++)
            {
                for (var j = i + 1; j < numColumns; j++)
                {
                    if (array[numSortRow, i] > array[numSortRow, j])
                    {
                        temp = array[numSortRow, i];

                        array[numSortRow, i] = array[numSortRow, j];

                        array[numSortRow, j] = temp;
                    }
                }
            }
        }
        #endregion

        ///<summary>
        /// Sorting all rows of an array from smallest to largest.
        ///</summary>
        #region SortAllRowArrayMinMax
        static void SortAllRowArrayMinMax()
        {
            double temp;

            for (var r = 0; r < numRows; r++)
            {
                for (var i = 0; i < numColumns; i++)
                {
                    for (var j = i + 1; j < numColumns; j++)
                    {
                        if (array[r, i] > array[r, j])
                        {
                            temp = array[r, i];

                            array[r, i] = array[r, j];

                            array[r, j] = temp;
                        }
                    }
                }
            }
            
        }
        #endregion

        ///<summary>
        /// Sorting the entire array from smallest to largest.
        ///</summary>
        #region SortAllMatrixMinMax
        static void SortAllMatrixMinMax()
        {
            double min;
            int num_i = 0, num_j = 0;

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    int temp2 = j;

                    min = array[i, j];

                    for (int a = i; a < numRows; a++)
                    {
                        for (int b = temp2; b < numColumns; b++)
                        {
                            if (min >= array[a, b])
                            {
                                min = array[a, b];

                                num_i = a;

                                num_j = b;
                            }
                        }
                        temp2 = 0;
                    }
                    var temp = array[i, j];

                    array[i, j] = array[num_i, num_j];

                    array[num_i, num_j] = temp;
                }
            }
        }
        #endregion

        ///<summary>
        /// Sorting any row of an array from largest to smallest.
        ///</summary>
        #region SortRowArrayMaxMin
        static void SortRowArrayMaxMin(int numSortRow)
        {
            double temp;

            for (var i = 0; i < numColumns; i++)
            {
                for (var j = i + 1; j < numColumns; j++)
                {
                    if (array[numSortRow, i] < array[numSortRow, j])
                    {
                        temp = array[numSortRow, i];

                        array[numSortRow, i] = array[numSortRow, j];

                        array[numSortRow, j] = temp;
                    }
                }
            }
        }
        #endregion

        ///<summary>
        /// Sorting all rows of an array from largest to smallest.
        ///</summary>
        #region SortAllRowArrayMaxMin
        static void SortAllRowArrayMaxMin()
        {
            double temp;

            for (var r = 0; r < numRows; r++)
            {
                for (var i = 0; i < numColumns; i++)
                {
                    for (var j = i + 1; j < numColumns; j++)
                    {
                        if (array[r, i] < array[r, j])
                        {
                            temp = array[r, i];

                            array[r, i] = array[r, j];

                            array[r, j] = temp;
                        }
                    }
                }
            }
        }
        #endregion

        ///<summary>
        /// Sorting the entire array from largest to smallest.
        ///</summary>
        #region SortAllMatrixMaxMin
        static void SortAllMatrixMaxMin()
        {
            double max;
            int num_i = 0, num_j = 0;

            for (var i = 0; i < numRows; i++)
            {
                for (var j = 0; j < numColumns; j++)
                {
                    int temp2 = j;

                    max = array[i, j];

                    for (var a = i; a < numRows; a++)
                    {
                        for (var b = temp2; b < numColumns; b++)
                        {
                            if (max <= array[a, b])
                            {
                                max = array[a, b];

                                num_i = a;

                                num_j = b;
                            }
                        }
                        temp2 = 0;
                    }

                    var temp = array[i, j];

                    array[i, j] = array[num_i, num_j];

                    array[num_i, num_j] = temp;
                }
            }
        }
        #endregion

        ///<summary>
        /// All logic.
        ///</summary>
        #region Start
        static void Start()
        {
            Console.Title = "Array";

            // Setting the height and width of the console window.
            Console.WindowWidth = 90;
            Console.WindowHeight = 40;

            ShowGreeting();

            Console.WriteLine();

            var helper = 0;

            while (true)
            {
                if (helper > 0)
                {
                    Console.Clear();
                }

                Menu();

                switch (EnterNumberMenu())
                {
                    case 1:
                        Case1();

                        break;
                    case 2:
                        Case2();

                        break;
                    case 3:
                        Case3();

                        break;
                    case 4:
                        Case4();

                        break;
                    case 5:
                        Case5();

                        break;
                    case 6:
                        Environment.Exit(0);

                        break;
                }

                helper++;
            }
        }
        #endregion

        ///<summary>
        /// Logic case 1.
        ///</summary>
        #region Case 1
        static void Case1()
        {
            Console.Clear();

            while (true)
            {
                try
                {
                    ReadNumRows();

                    ReadNumColumns();

                    array = new double[numRows, numColumns];

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    continue;
                }
            }

            Console.Clear();

            EnterElArray();
        }
        #endregion

        ///<summary>
        /// Logic case 2.
        ///</summary>
        #region Case 2
        static void Case2()
        {
            Console.Clear();

            var condition = numRows == 0 && numColumns == 0;

            if (condition)
            {
                Console.WriteLine("Your array hasn't been created yet.");
            }
            else
            {
                Console.WriteLine("Your array:");

                OutArray();

                NegativePositive();

                Console.WriteLine();

                Console.Write("Number of negative array elements: ");

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(numNegativeEl);

                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write("Number of positive array elements: ");

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(numPositiveEl);

                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine();
            }

            Console.ReadKey();
        }
        #endregion

        ///<summary>
        /// Logic case 3.
        ///</summary>
        #region Case 3
        static void Case3()
        {
            Console.Clear();

            var condition1 = numRows == 0 && numColumns == 0;

            if (condition1)
            {
                Console.WriteLine("Your array hasn't been created yet.");
            }
            else
            {
                Console.WriteLine("Your original array:");

                OutArray();

                var message = "\nSelect the sorting direction (from smallest to largest/largest to smallest)";

                Console.WriteLine(message);

                SmallSortMenu();

                int numSmallSortMenu = 0;

                numSmallSortMenu = EnterNumSmallSortMenu();

                if (numSmallSortMenu == 1)
                {
                    SortMenu();

                    int numSortMenu = EnterNumSorMenu();

                    Console.WriteLine("\nYour sorted array:");

                    if (numSortMenu <= numRows)
                    {
                        SortRowArrayMinMax(numSortMenu - 1);
                    }
                    else if (numSortMenu == numRows + 1)
                    {
                        SortAllRowArrayMinMax();
                    }
                    else
                    {
                        SortAllMatrixMinMax();
                    }
                }
                else
                {
                    SortMenu();

                    int numSortMenu = EnterNumSorMenu();

                    Console.WriteLine("\nYour sorted array:");

                    if (numSortMenu <= numRows)
                    {
                        SortRowArrayMaxMin(numSortMenu - 1);
                    }
                    else if (numSortMenu == numRows + 1)
                    {
                        SortAllRowArrayMaxMin();
                    }
                    else
                    {
                        SortAllMatrixMaxMin();
                    }
                }

                OutArray();
            }

            Console.ReadKey();
        }
        #endregion

        ///<summary>
        /// Logic case 4.
        ///</summary>
        #region Case 4
        static void Case4()
        {
            Console.Clear();

            var condition2 = numRows == 0 && numColumns == 0;

            if (condition2)
            {
                Console.WriteLine("Your array hasn't been created yet.");
            }
            else
            {
                Console.WriteLine("Your original array:");

                OutArray();

                Console.WriteLine("\nSelect item to invert");

                InverceMenu();

                int numInvMenu = EnterNumInvMenu();

                if (numInvMenu <= numRows)
                {
                    InvertRowArray(numInvMenu - 1);
                }
                else if (numInvMenu == numRows + 1)
                {
                    InvertAllLineArray();
                }
                else
                {
                    InvertAllArray();
                }

                Console.WriteLine("\nYour inverse array:");

                OutArray();

            }

            Console.ReadKey();
        }
        #endregion

        ///<summary>
        /// Logic case 5.
        ///</summary>
        #region Case 5
        static void Case5()
        {
            Console.Clear();

            AboutProgram();

            Console.ReadKey();
        }
        #endregion
    }
}
