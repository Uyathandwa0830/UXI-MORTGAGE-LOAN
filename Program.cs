using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Program
    {
        public class MortgageCalculator
        {
            // This method  calculates and returns the monthly repayment amount.
            public static double MonthlyRepayment(double loanAmount, double annualInterestRate, int loanTermYears)
            {
                double monthlyInterestRate = annualInterestRate / 12 / 100; // Montly interest rate
                int totalPayments = loanTermYears * 12; // Total number of payments

                double monthlyRepayment = loanAmount * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, totalPayments)) / (Math.Pow(1 + monthlyInterestRate, totalPayments) - 1);  //calculates the monthly repayment amount for a loan based on the loan amount, the annual interest rate, and the total number of payments

                return monthlyRepayment;
            }

            //This method  calculates and returns the total amount of interest paid over the life of the loan.
            public static double TotalInterestPaid(double loanAmount, double annualInterestRate, int loanTermYears)
            {
                double monthlyRepayment = MonthlyRepayment(loanAmount, annualInterestRate, loanTermYears);
                int totalPayments = loanTermYears * 12;


                double totalInterestPaid = (monthlyRepayment * totalPayments) - loanAmount; // calculates the total amount paid over the life of the loan

                return totalInterestPaid;
            }

            // This method calculates and return the total amount paid over the life of the loan.
            public static double TotalAmountPaid(double loanAmount, double annualInterestRate, int loanTermYears)
            {
                double monthlyRepayment = MonthlyRepayment(loanAmount, annualInterestRate, loanTermYears);
                int totalPayments = loanTermYears * 12;


                double totalAmountPaid = monthlyRepayment * totalPayments;

                return totalAmountPaid;
            }

            // This method generates and return an amortization schedule.
            public static List<AmortizationScheduleEntry> GenerateAmortizationSchedule(double loanAmount, double annualInterestRate, int loanTermYears)
            {
                List<AmortizationScheduleEntry> amortizationSchedule = new List<AmortizationScheduleEntry>();
                double monthlyInterestRate = annualInterestRate / 12 / 100; // Monthly interest rate
                int totalPayments = loanTermYears * 12; //  Total number of payments
                double monthlyRepayment = MonthlyRepayment(loanAmount, annualInterestRate, loanTermYears);

                double remainingBalance = loanAmount;

                for (int i = 1; i <= totalPayments; i++) //++ increment operator
                {
                    double interestPaid = remainingBalance * monthlyInterestRate;
                    double pupilPaid = monthlyRepayment - interestPaid; // calculates the portion of the monthly repayment that goes towards repaying the principal amount of the loan


                    remainingBalance -= pupilPaid;// subtraction assignment

                    AmortizationScheduleEntry entry = new AmortizationScheduleEntry
                    {
                        PaymentNumber = i,
                        PaymentAmount = monthlyRepayment,
                        InterestPaid = interestPaid,
                        ArtistPaid = pupilPaid,
                        RemainingBalance = remainingBalance
                    };

                    amortizationSchedule.Add(entry);
                }

                return amortizationSchedule;
            }
        }


        public class AmortizationScheduleEntry
        {
            public int PaymentNumber { get; set; }
            public double PaymentAmount { get; set; }
            public double InterestPaid { get; set; }
            public double ArtistPaid { get; set; }
            public double RemainingBalance { get; set; }
            public double pupilPaid { get; set; }
        }


        // display the MainMenuConsole.WriteLine();
        public static int GetMenuOption()

        {

            Console.WriteLine("\n========== Main Menu ==========");
            Console.WriteLine("\nWhat would you like to do:");
            Console.WriteLine(" (1) Calculate Monthly repayment \n (2) Calculate Total interest paid \n (3) Calculate amount paid \n (4) Generate amortization schedule \n (5) Enter new values \n (6) Exit");


            Console.WriteLine("\nPlease enter your choice:"); //user input

            string menuUserInput;
            int menuInt;
            menuUserInput = Console.ReadLine();
            menuInt = Convert.ToInt32(menuUserInput);


            // return the response

            return menuInt;

        }

        public static int menuStart()
        {

            Console.WriteLine("Press 1 to start app or 0 to exit:");

            string userInput;
            int startInt;
            userInput = Console.ReadLine();
            startInt = Convert.ToInt32(userInput);

            return startInt;
        }


        class MortageCalculator
        {
            static void Main(string[] args)
            {


                int startint = menuStart();

                if (startint == 0)
                {

                    Console.WriteLine("Exit the app.");
                    System.Environment.Exit(0);
                }

                else if (startint == 1)
                {


                    Console.WriteLine("WELCOME TO MORTAGE CALCULATOR.");
                    Console.WriteLine("Enter loan amount: ");

                    string userInput1;
                    double startint1;
                    userInput1 = Console.ReadLine();
                    startint1 = Convert.ToDouble(userInput1);

                    double loanAmount = startint1;

                    Console.WriteLine("Enter your interest rate: ");
                    string userInput2;
                    double startint2;
                    userInput2 = Console.ReadLine();
                    startint2 = Convert.ToDouble(userInput2);

                    double annualInterestRate = startint2;

                    Console.WriteLine("Enter how many years the loan needs to be paid off : ");
                    string userInput3;
                    int startint3;
                    userInput3 = Console.ReadLine(); //is a method that reads the next line of characters  and returns it as a string
                    startint3 = Convert.ToInt32(userInput3);

                    int loanTermYears = startint3;


                    bool menuRunning = true;

                    while (menuRunning)
                    {
                        int entry1 = GetMenuOption();

                        if (entry1 == 1)
                        {

                            double roundMonthLoanRepayment = Math.Round(MortgageCalculator.MonthlyRepayment(loanAmount, annualInterestRate, loanTermYears), 2);

                            Console.WriteLine("Choice: 1\n With a loan amount of " + loanAmount + "." + " An interest rate of: " + annualInterestRate + "%" + " and a loan term of " + loanTermYears + " years. The monthly loan repayment will be: " + roundMonthLoanRepayment + "p/m");
                            //Console.WriteLine("Press any key to continue . . . ");

                        }

                        else if (entry1 == 2)
                        {

                            double roundTotalInterestPaid = Math.Round(MortgageCalculator.TotalInterestPaid(loanAmount, annualInterestRate, loanTermYears), 2);

                            Console.WriteLine("Choice: 2\n With a loan amount of " + loanAmount + "." + " An interest rate of: " + annualInterestRate + "%" + " and a loan term of " + loanTermYears + " years. the total interest paid will be: " + roundTotalInterestPaid);

                        }

                        else if (entry1 == 3)
                        {

                            double roundTotalAmount = Math.Round(MortgageCalculator.TotalAmountPaid(loanAmount, annualInterestRate, loanTermYears), 2);

                            Console.WriteLine("Choice: 3\n With a loan amount of " + loanAmount + "." + " An interest rate of: " + annualInterestRate + "%" + " and a loan term of " + loanTermYears + " years. the total amount paid will be: " + roundTotalAmount);
                        }



                        else if (entry1 == 4)
                        {

                            List<AmortizationScheduleEntry> schedule = MortgageCalculator.GenerateAmortizationSchedule(loanAmount, annualInterestRate, loanTermYears);
                            Console.WriteLine("\nAmortization Schedule:");

                            foreach (var entry in schedule)
                            {
                                entry.PaymentAmount = Math.Round(entry.PaymentAmount, 2);
                                entry.InterestPaid = Math.Round(entry.InterestPaid, 2);
                                entry.ArtistPaid = Math.Round(entry.ArtistPaid, 2);
                                entry.RemainingBalance = Math.Round(entry.RemainingBalance, 2);

                                Console.WriteLine("Payment #" + entry.PaymentNumber + ": Payment Amount:" + entry.PaymentAmount.ToString() + ", Interest Paid: " + entry.InterestPaid + ", Principal Amount: " + entry.ArtistPaid + ", Remaining Balance: " + entry.RemainingBalance);



                            }

                        }
                        else if (entry1 == 5)
                        {

                            menuRunning = false;

                        }
                        else if (entry1 == 6)
                        {

                            menuRunning = false;
                            System.Environment.Exit(0);
                        }

                        else
                        {

                            menuRunning = false;
                            Console.WriteLine("Please enter valid input. . .");
                            GetMenuOption();
                        }


                    }


                }
                else
                {

                    Console.WriteLine("Please enter valid input, 0 or 1.");
                    menuStart();
                }

                return;
            }
        }
    }
}