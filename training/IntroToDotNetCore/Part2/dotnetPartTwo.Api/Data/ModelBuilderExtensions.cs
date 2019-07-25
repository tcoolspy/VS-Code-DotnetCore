using Microsoft.EntityFrameworkCore;
using dotnetPartTwo.Core.Models;
using System;

namespace dotnetPartTwo.Api.Data
{
    public static class ModelBuilderExtensions
    {
       public static void Seed(this ModelBuilder modelBuilder)
        {
            // NOTE: these course names and descriptions are from UAB's Computer Science Catalog
            // http://catalog.uab.edu/undergraduate/collegeofartsciences/computerscience/#courseinventory            
            modelBuilder.Entity<Course>().HasData
            (
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 102",
                    CourseHours = 4,
                    CourseName = "Principles of Computer Science",
                    CourseDescription = @"This is an introductory course for non-CS majors to learn the 
                                        fundamental concepts and topics of Computer Science (CS), and how 
                                         CS is now impacting and changing every person's way of life. 
                                        Students will explore the use of block-based and/or text-based 
                                        programming languages to form computational solutions to problems. 
                                        The main topics covered include program design, software development, 
                                        abstract thinking, information analysis, the Internet, algorithmic 
                                        methodology. The course will also discuss other topics including 
                                        (but not limited to) modeling real-life phenomena, computing as 
                                        a creative activity, social uses and abuses of information, and 
                                        the foundations of cybersecurity. This course has a laboratory component."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 103",
                    CourseHours = 4,
                    CourseName = "Introduction to Computer Science in Python",
                    CourseDescription = @"An introduction to computation and computational thinking, explored 
                                        through programming in Python. Python is a scripting programming language 
                                        that encourages exploration and quick development. This course assumes 
                                        no prior programming experience and is appropriate for students in 
                                        any discipline, such as linguistics, biology, business, and art. The 
                                        student will leave the course with the ability to write clear and 
                                        well-designed programs that solve interesting problems, and an 
                                        appreciation of the power and beauty of computation. Strings, tuples, 
                                        lists, dictionaries; branching, iteration, abstraction through functions,
                                        recursion, higher order programming; insertion sort, binary search, 
                                        turtle graphics, binary numbers, introduction to classes. Principles 
                                        of software development are emphasized, including specification, 
                                        documentation, testing, debugging, exception handling. This course 
                                        has a laboratory component."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 104",
                    CourseHours = 4,
                    CourseName = "Introduction to Data Science",
                    CourseDescription = @"Spurred by the recent proliferation of large datasets and the maturation 
                                        of techniques such as machine learning, data science is revolutionizing 
                                        modern computer science in the twenty-first century. In this introductory 
                                        course, students will develop an understanding of the modern use of 
                                        computer science to analyze data, to make predictions from large datasets,
                                        to cluster and classify data, to analyze the reliability of conclusions 
                                        drawn from data, and to communicate data visually. Empirical analysis 
                                        includes datasets from areas including economics, medicine, and geography. 
                                        The course introduces Python to explore and analyze data in code 
                                        (no previous experience with Python is necessary). Computational tools 
                                        covered include basic probability, inference, linear regression, least 
                                        squares, and nearest neighbors."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 130",
                    CourseHours = 3,
                    CourseName = "Introduction to Cyber Security",
                    CourseDescription = @"This course introduces students to the rapidly evolving and critical 
                                        international arenas of privacy, information security, and critical 
                                        infrastructure, and is designed to develop knowledge and skills for 
                                        security of information and information systems at both individual and 
                                        organizational levels. Stakeholders of information security and privacy. 
                                        Framework of information security and privacy. Nature of common 
                                        information hazards. Common cyber attacks and counter-measures. 
                                        Operation and limitations of information and system safeguards. 
                                        Ethics, privacy, policy and information decisions. Legal aspects, 
                                        professional practices, and standards for information security and privacy.
                                        Security of national critical infrastructures."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 203",
                    CourseHours = 4,
                    CourseName = "Object-Oriented Programming",
                    CourseDescription = @"A second course in computational thinking, through the lens of object oriented 
                                        programming. Fundamental concepts of object oriented programming and basic 
                                        data structures. Types, classes, objects, inheritance, containers, 
                                        OO software design, program structure and organization, reflection, 
                                        generic programming. Lists, trees, stacks, queues, heaps, search trees, 
                                        hash tables, graphs, complexity analysis. This course has a laboratory 
                                        component."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 221",
                    CourseHours = 4,
                    CourseName = "Web Development",
                    CourseDescription = @"Fundamental concepts of web development. Client side application 
                                        development using web languages and technologies. Client-server communication. 
                                        Responsive design. User interaction models. Server-side development. 
                                        This course has a laboratory component."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 250",
                    CourseHours = 3,
                    CourseName = "Discrete Structures",
                    CourseDescription = @"Discrete mathematics for computer science, including elementary 
                                        propositional and predicate logic, sets, relations, functions, counting, 
                                        elementary graph theory, proof techniques including proof by induction, 
                                        proof by contradiction, and proof by construction."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 303",
                    CourseHours = 3,
                    CourseName = "Algorithms and Data Structures",
                    CourseDescription = @"Techniques for design and analysis of algorithms; efficient algorithms 
                                        for sorting, searching, graphs, and string matching; and design techniques 
                                        such as divide-and-conquer, recursive backtracking, dynamic programming, 
                                        and greedy algorithms."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 330",
                    CourseHours = 3,
                    CourseName = "Computer Organization and Assembly Language Programming",
                    CourseDescription = @"Register-level architecture of modern digital computer 
                                        systems, digital logic, machine-level representation of data, 
                                        assembly-level machine organization, and alternative architectures. 
                                        Laboratory emphasizes machine instruction execution, addressing 
                                        techniques, program segmentation and linkage, macro definition and 
                                        generation, and computer solution of problems in assembly language."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 332",
                    CourseHours = 3,
                    CourseName = "Systems Programming",
                    CourseDescription = @"Unix architecture and internals with an emphasis on Linux, shell scripting, 
                                        distributions of Linux for various computing platforms including 
                                        large and desktop computers, and embedded computing devices, introduction 
                                        to the C programming language, systems programming in C covering signals 
                                        and process control, networking, I/O, concurrency and synchronization, 
                                        memory allocation, threads, debugging, library development and usa"
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 334",
                    CourseHours = 3,
                    CourseName = "Networking",
                    CourseDescription = @"Underlying network technology, including IEEE 802.11. Interconnecting 
                                        networks using bridges and routers. IP addresses and datagram formats. 
                                        Static and dynamic routing algorithms. Control messages. Subnet and 
                                        supernet extensions. UDP and TCP. File transfer protocols. E-mail and 
                                        the World Wide Web. Network address translation and firewalls. Mandatory 
                                        weekly Linux-based lab."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 350",
                    CourseHours = 3,
                    CourseName = "Automata and Formal Languages",
                    CourseDescription = @"Finite-state automata and regular expressions, context-free grammars and pushdown automata, computability."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 355",
                    CourseHours = 3,
                    CourseName = "Probability and Statistics in Computer Science",
                    CourseDescription = @"Introduction to probability and statistics with applications in 
                                        computer science. Counting, permutations and combinations. Probability, 
                                        conditional probability, Bayes theorem. Standard probability distributions. 
                                        Measures of central tendency and dispersion. Central Limit Theorem. 
                                        Hypothesis testing. Random number generation. Random algorithms. 
                                        Estimating probabilities by simulation."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 380",
                    CourseHours = 3,
                    CourseName = "Matrix Computation",
                    CourseDescription = @"Matrix computation is the foundation of data science, of many key areas 
                                        of computer science (machine learning, computer graphics, computer vision, 
                                        high performance computing), and of companies like Google. The main object 
                                        of study in this course is the matrix, including matrix computation 
                                        (matrix multiplication, null space, solution of linear systems, least squares) 
                                        and applications (e.g., image filtering, face detection, compression)."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 401",
                    CourseHours = 3,
                    CourseName = "Programming Languages",
                    CourseDescription = @"CS401 is a programming language overview course. The course will discuss 
                                        computability, lexing, parsing, type systems, and ways to formalize a 
                                        language's semantics. The course will introduce students to major 
                                        programming paradigms, such as functional programming and logic programming, 
                                        and their realization in programming languages. Students will solve problems 
                                        using different paradigms and study the impact on program design and 
                                        implementation. The course enables students to assess strengths and 
                                        weaknesses of different languages for problem solving."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 402",
                    CourseHours = 3,
                    CourseName = "Compiler Design",
                    CourseDescription = @"Study the design and implementation of compilers, including front-end 
                                        (lexer, parser, type checking), to mid-end (intermediate representations, 
                                        control-flow analysis, dataflow analysis, and optimizations) to back-end 
                                        (code generation). Students will get hands-on experience by implementing 
                                        several compiler components."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 403",
                    CourseHours = 3,
                    CourseName = "Cloud Computing",
                    CourseDescription = @"Introduction to cloud computing architectures and programming 
                                        paradigms. Theoretical and practical aspects of cloud programming 
                                        and problem-solving involving compute, storage and network 
                                        virtualization. Design, development, analysis, and evaluation 
                                        of solutions in cloud computing space including machine and 
                                        container virtualization technologies."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 410",
                    CourseHours = 3,
                    CourseName = "Database Application Development",
                    CourseDescription = @"Relational model of databases, structured query language, relational 
                                        database design and application development, database normal forms, and 
                                        security and integrity of databases."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 416",
                    CourseHours = 3,
                    CourseName = "Big Data Programming.",
                    CourseDescription = @"Introduction to Big Data, Properties of Big Data, platforms, programming 
                                        models, applications, business analytics programming, big data processing 
                                        with Python, R, and SAS, MapReduce programming with Hadoop."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 417",
                    CourseHours = 3,
                    CourseName = "Database Security",
                    CourseDescription = @"Database fundamentals, introduction to database security, overview of 
                                        security models, access control models, covert channels and inference 
                                        channels, MySQL security, Oracle security, Oracle label security, 
                                        developing a database security plan, SQL server security, security 
                                        of statistical databases, security and privacy issues of data mining, 
                                        database applications security, SQL injection, defensive programming, 
                                        database intrusion prevention, audit, fault tolerance and recovery, 
                                        Hippocratic databases, XML security, network security, biometrics, 
                                        cloud database security, big database security."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 420",
                    CourseHours = 3,
                    CourseName = "Software Engineering",
                    CourseDescription = @"Design and implementation of large-scale software systems, 
                                        software development life cycle, software requirements and specifications, 
                                        software design and implementation, verification and validation, project 
                                        management and team-oriented software development. Lecture and laboratory."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 421",
                    CourseHours = 3,
                    CourseName = "Advanced Web Application Development",
                    CourseDescription = @"Introduction to web application design and development. Includes 
                                        traditional web applications utilizing server-side scripting as well 
                                        as client/server platforms. Covers responsive design for both mobile 
                                        and desktop users, as well as hands on server provisioning and 
                                        configuration. Other topics include web security problems and practices, 
                                        authentication, database access, application deployment and Web API design, 
                                        such as REpresentational State Transfer (REST)."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 422",
                    CourseHours = 3,
                    CourseName = "Mobile Application Development",
                    CourseDescription = @"Fundamental concepts of mobile application development. Hybrid 
                                        application development using web application technologies. Mobile 
                                        form factor specific concerns. Client-server communication. Multi-screen 
                                        design. Mobile application UX. Native development basics. This course 
                                        has a laboratory component."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 427",
                    CourseHours = 3,
                    CourseName = "Software Design and Integration",
                    CourseDescription = @"This course provides hands-on experience in the design and integration 
                                        of software systems. Component-based technology, model-driven technology, 
                                        service-oriented technology, and cloud technology are all explored. 
                                        Software design basics, including the decomposition of systems into 
                                        recognizable patterns, the role of patterns in designing software and 
                                        design refactoring, and attributes of good design. Agile culture, 
                                        CASE tools, tools for continuous integration, build, testing, and 
                                        version control."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 430",
                    CourseHours = 3,
                    CourseName = "Computer Architecture",
                    CourseDescription = @"Introduction to computer architecture, including memory subsystems, 
                                        direct-mapped and set-associative cache and multi-level cache subsystems, 
                                        direct- access devices including RAID and SCSI disk drives, processor 
                                        pipelining including super-scalar and vector machines, parallel 
                                        architectures including SMP, NUMA and distributed memory systems, 
                                        Interrupt mechanisms, and future microprocessor design issues."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 431",
                    CourseHours = 3,
                    CourseName = "Distributed Systems",
                    CourseDescription = @"Introduction to distributed systems, distributed hardware and 
                                        software concepts, communication, processes, naming, synchronization, 
                                        consistency and replication, fault tolerance, security, client/server 
                                        computing, web technologies, enterprise technologies."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 432",
                    CourseHours = 3,
                    CourseName = "Parallel Computing",
                    CourseDescription = @"Introduction to parallel computing architectures and programming paradigms. 
                                        Theoretical and practical aspects of parallel programming and problem solving. 
                                        Design, development, analysis, and evaluation of parallel algorithms."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    CourseIdentifier = "CS 433",
                    CourseHours = 3,
                    CourseName = "Operating Systems",
                    CourseDescription = @"Introduction to operating systems. This course looks at the internal design 
                                        and operation of a modern operating system. Topics include interrupt handling, 
                                        process scheduling, memory management, virtual memory, demand paging, 
                                        file space allocation, file and directory management, file/user security 
                                        and file access methods. Several comparisons among current operating systems 
                                        are used, with attention to Windows and Unix in particular."
                }
            );
        }
    }
}