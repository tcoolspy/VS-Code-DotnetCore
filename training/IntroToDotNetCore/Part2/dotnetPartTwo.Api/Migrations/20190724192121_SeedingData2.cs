using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetPartTwo.Api.Migrations
{
    public partial class SeedingData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("51996dd8-e11c-4b3b-ad65-1a1f56a75474"), @"This is an introductory course for non-CS majors to learn the 
                                        fundamental concepts and topics of Computer Science (CS), and how 
                                         CS is now impacting and changing every person's way of life. 
                                        Students will explore the use of block-based and/or text-based 
                                        programming languages to form computational solutions to problems. 
                                        The main topics covered include program design, software development, 
                                        abstract thinking, information analysis, the Internet, algorithmic 
                                        methodology. The course will also discuss other topics including 
                                        (but not limited to) modeling real-life phenomena, computing as 
                                        a creative activity, social uses and abuses of information, and 
                                        the foundations of cybersecurity. This course has a laboratory component.", 4, "CS 102", "Principles of Computer Science" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("386f717c-d1b7-4a96-a50d-899191455ffc"), @"Introduction to distributed systems, distributed hardware and 
                                        software concepts, communication, processes, naming, synchronization, 
                                        consistency and replication, fault tolerance, security, client/server 
                                        computing, web technologies, enterprise technologies.", 3, "CS 431", "Distributed Systems" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("21fb458d-32bf-4661-a947-ee3998801e8f"), @"Introduction to computer architecture, including memory subsystems, 
                                        direct-mapped and set-associative cache and multi-level cache subsystems, 
                                        direct- access devices including RAID and SCSI disk drives, processor 
                                        pipelining including super-scalar and vector machines, parallel 
                                        architectures including SMP, NUMA and distributed memory systems, 
                                        Interrupt mechanisms, and future microprocessor design issues.", 3, "CS 430", "Computer Architecture" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("122a3cf9-e487-45f3-bd8d-2b7bdf80c5b8"), @"This course provides hands-on experience in the design and integration 
                                        of software systems. Component-based technology, model-driven technology, 
                                        service-oriented technology, and cloud technology are all explored. 
                                        Software design basics, including the decomposition of systems into 
                                        recognizable patterns, the role of patterns in designing software and 
                                        design refactoring, and attributes of good design. Agile culture, 
                                        CASE tools, tools for continuous integration, build, testing, and 
                                        version control.", 3, "CS 427", "Software Design and Integration" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("411c223c-198a-4843-826e-7353328f4fe0"), @"Fundamental concepts of mobile application development. Hybrid 
                                        application development using web application technologies. Mobile 
                                        form factor specific concerns. Client-server communication. Multi-screen 
                                        design. Mobile application UX. Native development basics. This course 
                                        has a laboratory component.", 3, "CS 422", "Mobile Application Development" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("5adfef40-3406-48fc-b3d6-08852d6f7afc"), @"Introduction to web application design and development. Includes 
                                        traditional web applications utilizing server-side scripting as well 
                                        as client/server platforms. Covers responsive design for both mobile 
                                        and desktop users, as well as hands on server provisioning and 
                                        configuration. Other topics include web security problems and practices, 
                                        authentication, database access, application deployment and Web API design, 
                                        such as REpresentational State Transfer (REST).", 3, "CS 421", "Advanced Web Application Development" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("3e80c623-630a-4e19-b584-4d3516a1ff51"), @"Design and implementation of large-scale software systems, 
                                        software development life cycle, software requirements and specifications, 
                                        software design and implementation, verification and validation, project 
                                        management and team-oriented software development. Lecture and laboratory.", 3, "CS 420", "Software Engineering" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("b0f8008a-401d-4da5-9070-14ce99ded120"), @"Database fundamentals, introduction to database security, overview of 
                                        security models, access control models, covert channels and inference 
                                        channels, MySQL security, Oracle security, Oracle label security, 
                                        developing a database security plan, SQL server security, security 
                                        of statistical databases, security and privacy issues of data mining, 
                                        database applications security, SQL injection, defensive programming, 
                                        database intrusion prevention, audit, fault tolerance and recovery, 
                                        Hippocratic databases, XML security, network security, biometrics, 
                                        cloud database security, big database security.", 3, "CS 417", "Database Security" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("d9ed12d3-af10-460d-9c4f-9b1ec82385fe"), @"Introduction to Big Data, Properties of Big Data, platforms, programming 
                                        models, applications, business analytics programming, big data processing 
                                        with Python, R, and SAS, MapReduce programming with Hadoop.", 3, "CS 416", "Big Data Programming." });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("e0798fa2-9ba6-432b-bf52-abd271656c37"), @"Relational model of databases, structured query language, relational 
                                        database design and application development, database normal forms, and 
                                        security and integrity of databases.", 3, "CS 410", "Database Application Development" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("c5c81501-f2ff-4dc6-b2cd-5a86873c5bd4"), @"Introduction to cloud computing architectures and programming 
                                        paradigms. Theoretical and practical aspects of cloud programming 
                                        and problem-solving involving compute, storage and network 
                                        virtualization. Design, development, analysis, and evaluation 
                                        of solutions in cloud computing space including machine and 
                                        container virtualization technologies.", 3, "CS 403", "Cloud Computing" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("bd431b9f-de76-48f5-aba0-320f0423c6ec"), @"Study the design and implementation of compilers, including front-end 
                                        (lexer, parser, type checking), to mid-end (intermediate representations, 
                                        control-flow analysis, dataflow analysis, and optimizations) to back-end 
                                        (code generation). Students will get hands-on experience by implementing 
                                        several compiler components.", 3, "CS 402", "Compiler Design" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("f80a4644-788f-4925-a1ac-93162beafd21"), @"CS401 is a programming language overview course. The course will discuss 
                                        computability, lexing, parsing, type systems, and ways to formalize a 
                                        language's semantics. The course will introduce students to major 
                                        programming paradigms, such as functional programming and logic programming, 
                                        and their realization in programming languages. Students will solve problems 
                                        using different paradigms and study the impact on program design and 
                                        implementation. The course enables students to assess strengths and 
                                        weaknesses of different languages for problem solving.", 3, "CS 401", "Programming Languages" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("18967849-2762-422a-ac76-b637d56936d4"), @"Matrix computation is the foundation of data science, of many key areas 
                                        of computer science (machine learning, computer graphics, computer vision, 
                                        high performance computing), and of companies like Google. The main object 
                                        of study in this course is the matrix, including matrix computation 
                                        (matrix multiplication, null space, solution of linear systems, least squares) 
                                        and applications (e.g., image filtering, face detection, compression).", 3, "CS 380", "Matrix Computation" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("67e9598b-9950-40f4-b5b1-321d64245ad2"), @"Introduction to probability and statistics with applications in 
                                        computer science. Counting, permutations and combinations. Probability, 
                                        conditional probability, Bayes theorem. Standard probability distributions. 
                                        Measures of central tendency and dispersion. Central Limit Theorem. 
                                        Hypothesis testing. Random number generation. Random algorithms. 
                                        Estimating probabilities by simulation.", 3, "CS 355", "Probability and Statistics in Computer Science" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("3951f726-fb26-4e4b-9f14-ff27499696b2"), "Finite-state automata and regular expressions, context-free grammars and pushdown automata, computability.", 3, "CS 350", "Automata and Formal Languages" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("617ede3a-2e4d-4add-a1aa-a969178e81ae"), @"Underlying network technology, including IEEE 802.11. Interconnecting 
                                        networks using bridges and routers. IP addresses and datagram formats. 
                                        Static and dynamic routing algorithms. Control messages. Subnet and 
                                        supernet extensions. UDP and TCP. File transfer protocols. E-mail and 
                                        the World Wide Web. Network address translation and firewalls. Mandatory 
                                        weekly Linux-based lab.", 3, "CS 334", "Networking" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("a961e3e4-6cd3-4ac8-abf2-49f01878c89d"), @"Unix architecture and internals with an emphasis on Linux, shell scripting, 
                                        distributions of Linux for various computing platforms including 
                                        large and desktop computers, and embedded computing devices, introduction 
                                        to the C programming language, systems programming in C covering signals 
                                        and process control, networking, I/O, concurrency and synchronization, 
                                        memory allocation, threads, debugging, library development and usa", 3, "CS 332", "Systems Programming" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("f5ebe8e1-c5dd-41bb-8a1b-8b50acd0af70"), @"Register-level architecture of modern digital computer 
                                        systems, digital logic, machine-level representation of data, 
                                        assembly-level machine organization, and alternative architectures. 
                                        Laboratory emphasizes machine instruction execution, addressing 
                                        techniques, program segmentation and linkage, macro definition and 
                                        generation, and computer solution of problems in assembly language.", 3, "CS 330", "Computer Organization and Assembly Language Programming" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("61f19eb3-d58f-42f6-a0e7-f5c9104313e5"), @"Techniques for design and analysis of algorithms; efficient algorithms 
                                        for sorting, searching, graphs, and string matching; and design techniques 
                                        such as divide-and-conquer, recursive backtracking, dynamic programming, 
                                        and greedy algorithms.", 3, "CS 303", "Algorithms and Data Structures" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("1ba61bdb-ebfb-42fc-b540-06dd79ed6de3"), @"Discrete mathematics for computer science, including elementary 
                                        propositional and predicate logic, sets, relations, functions, counting, 
                                        elementary graph theory, proof techniques including proof by induction, 
                                        proof by contradiction, and proof by construction.", 3, "CS 250", "Discrete Structures" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("fea03522-8e97-4365-87f1-1bd3e28bc43b"), @"Fundamental concepts of web development. Client side application 
                                        development using web languages and technologies. Client-server communication. 
                                        Responsive design. User interaction models. Server-side development. 
                                        This course has a laboratory component.", 4, "221", "Web Development" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("907471c4-49a9-4ea2-a439-6694cdba5d6d"), @"A second course in computational thinking, through the lens of object oriented 
                                        programming. Fundamental concepts of object oriented programming and basic 
                                        data structures. Types, classes, objects, inheritance, containers, 
                                        OO software design, program structure and organization, reflection, 
                                        generic programming. Lists, trees, stacks, queues, heaps, search trees, 
                                        hash tables, graphs, complexity analysis. This course has a laboratory 
                                        component.", 4, "CS 203", "Object-Oriented Programming" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("f4404de3-dbaa-4c9c-8c63-7afb6ce859d7"), @"This course introduces students to the rapidly evolving and critical 
                                        international arenas of privacy, information security, and critical 
                                        infrastructure, and is designed to develop knowledge and skills for 
                                        security of information and information systems at both individual and 
                                        organizational levels. Stakeholders of information security and privacy. 
                                        Framework of information security and privacy. Nature of common 
                                        information hazards. Common cyber attacks and counter-measures. 
                                        Operation and limitations of information and system safeguards. 
                                        Ethics, privacy, policy and information decisions. Legal aspects, 
                                        professional practices, and standards for information security and privacy.
                                        Security of national critical infrastructures.", 3, "CS 130", "Introduction to Cyber Security" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("1e6855fc-10b5-47e7-b9e5-042ab3486367"), @"Spurred by the recent proliferation of large datasets and the maturation 
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
                                        squares, and nearest neighbors.", 4, "CS 104", "Introduction to Data Science" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("4e264b91-7336-487a-973e-c722625e91ac"), @"An introduction to computation and computational thinking, explored 
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
                                        has a laboratory component.", 4, "CS 103", "Introduction to Computer Science in Python" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("f237dd45-5204-42ed-b904-a6617d23dccb"), @"Introduction to parallel computing architectures and programming paradigms. 
                                        Theoretical and practical aspects of parallel programming and problem solving. 
                                        Design, development, analysis, and evaluation of parallel algorithms.", 3, "CS 432", "Parallel Computing" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseHours", "CourseIdentifier", "CourseName" },
                values: new object[] { new Guid("2f00aade-3acc-4580-aee4-81ccb96f15dc"), @"Introduction to operating systems. This course looks at the internal design 
                                        and operation of a modern operating system. Topics include interrupt handling, 
                                        process scheduling, memory management, virtual memory, demand paging, 
                                        file space allocation, file and directory management, file/user security 
                                        and file access methods. Several comparisons among current operating systems 
                                        are used, with attention to Windows and Unix in particular.", 3, "CS 433", "Operating Systems" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("122a3cf9-e487-45f3-bd8d-2b7bdf80c5b8"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("18967849-2762-422a-ac76-b637d56936d4"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("1ba61bdb-ebfb-42fc-b540-06dd79ed6de3"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("1e6855fc-10b5-47e7-b9e5-042ab3486367"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("21fb458d-32bf-4661-a947-ee3998801e8f"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("2f00aade-3acc-4580-aee4-81ccb96f15dc"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("386f717c-d1b7-4a96-a50d-899191455ffc"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("3951f726-fb26-4e4b-9f14-ff27499696b2"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("3e80c623-630a-4e19-b584-4d3516a1ff51"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("411c223c-198a-4843-826e-7353328f4fe0"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("4e264b91-7336-487a-973e-c722625e91ac"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("51996dd8-e11c-4b3b-ad65-1a1f56a75474"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("5adfef40-3406-48fc-b3d6-08852d6f7afc"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("617ede3a-2e4d-4add-a1aa-a969178e81ae"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("61f19eb3-d58f-42f6-a0e7-f5c9104313e5"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("67e9598b-9950-40f4-b5b1-321d64245ad2"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("907471c4-49a9-4ea2-a439-6694cdba5d6d"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("a961e3e4-6cd3-4ac8-abf2-49f01878c89d"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("b0f8008a-401d-4da5-9070-14ce99ded120"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("bd431b9f-de76-48f5-aba0-320f0423c6ec"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("c5c81501-f2ff-4dc6-b2cd-5a86873c5bd4"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("d9ed12d3-af10-460d-9c4f-9b1ec82385fe"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("e0798fa2-9ba6-432b-bf52-abd271656c37"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("f237dd45-5204-42ed-b904-a6617d23dccb"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("f4404de3-dbaa-4c9c-8c63-7afb6ce859d7"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("f5ebe8e1-c5dd-41bb-8a1b-8b50acd0af70"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("f80a4644-788f-4925-a1ac-93162beafd21"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("fea03522-8e97-4365-87f1-1bd3e28bc43b"));
        }
    }
}
