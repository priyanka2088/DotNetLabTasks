namespace BookLibrary
{
    public class Book
    {
            //properties
            public int BookID{ get; set; }
            public string BookName{ get; set; }
            public string ISBNNo{ get; set; }
            public double Price{ get; set; }
            public string Publisher{ get; set; }
            public int NumberOfPages{ get; set; }
            public string Language{ get; set; }
            public string LoT{ get; set; }
            public string Summary{ get; set; }

            //constructor
            public Book(int id, string name, string isbn, double price, string publisher,
                        int pages, string language = "English", string lot = "Technical", string summary = "")
            {
                BookID = id;
                BookName = name;
                ISBNNo = isbn;
                Price = price;
                Publisher = publisher;
                NumberOfPages = pages;
                Language = language;
                LoT = lot;
                Summary = summary;
            }

            //AddBookDetails Method
            public void AddBookDetails()
            {

                bool IsValidIdData = false;
                while (!IsValidIdData)
                {
                    Console.WriteLine("Enter The 5 Digit Book ID : ");
                    string bookId = Console.ReadLine();
                    //Checking BookId is Null or Empty
                    if (string.IsNullOrEmpty(bookId))
                    {
                       Console.WriteLine("Book ID cannot be Null or Empty,Please Enter Correct Book Id");
                    }
                    else
                    {
                        bool IsInteger = int.TryParse(bookId, out int parsedId);

                        //Checking BookID is 5 Digit or Not
                        if (IsInteger && bookId.Length == 5)
                        {
                            BookID = parsedId;
                            IsValidIdData = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Book Id. Please enter 5-digit Book Id number.");
                        }
                    }
                }

            bool IsValidNameData = false;
            while (!IsValidNameData)
            {
                Console.WriteLine("Enter Book Name: ");
                BookName = Console.ReadLine();
                //Checking Book Name is Null or Empty
                if (string.IsNullOrEmpty(BookName))
                {
                    Console.WriteLine("Book Name cannot be Null or Empty, Please Enter Correct Book Name");
                }
                else
                {
                    IsValidNameData = true;
                }
            }

                Console.WriteLine("Enter ISBN Number: ");
                ISBNNo = Console.ReadLine();

            //Validating Price Type
            bool IsVaildPrice = false;
            while (!IsVaildPrice)
            {
                Console.WriteLine("Enter Price: ");
                String priceValue = Console.ReadLine();
                IsVaildPrice = double.TryParse(priceValue, out double parcedPrice);
                if (IsVaildPrice)
                {
                    Price = parcedPrice;
                }
                else
                {
                    Console.WriteLine("Enter Price in correct Format");
                }

            }

            Console.WriteLine("Enter Publisher: ");
                Publisher = Console.ReadLine();

            //Validating PageNo Type
            bool IsVaildPageNo = false;
            while (!IsVaildPageNo)
            {
                Console.WriteLine("Enter Number of Pages: ");
                String pageNo = Console.ReadLine();
                IsVaildPageNo = int.TryParse(pageNo, out int parcedPageNo);
                if (IsVaildPageNo)
                {
                    NumberOfPages = parcedPageNo;
                }
                else
                {
                    Console.WriteLine("Enter No of Pages in Correct Format");
                }

            }

                // Validation for Language and LoT
                Console.WriteLine("Enter Language (Press Enter  for default 'English'): ");
                Language = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(Language))
                {
                    Language = "English";
                }

                bool IsValidLotData = false;
                while (!IsValidLotData)
                {
                    Console.WriteLine("Enter LoT (.NET, Java, IMS, V&V, BI, RDBMS): ");
                    LoT = Console.ReadLine();

                    
                    // Check if LoT is Present in the Specified Value
                    if (LoT.ToLower() == ".net" || LoT.ToLower() == "java" || LoT.ToLower() == "ims" || LoT.ToLower() == "v&v" || LoT.ToLower() == "bi" || LoT.ToLower() == "rdbms")
                    {
                        IsValidLotData = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid LoT. Please choose one from the given List: .NET, Java, IMS, V&V, BI, RDBMS.");
                    }
                }
            }
        }
    }