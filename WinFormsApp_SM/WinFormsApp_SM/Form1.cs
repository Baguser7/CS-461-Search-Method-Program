using CsvHelper; //Using csvhelper package from NuGet
using CsvHelper.Configuration;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using WinFormsApp_SM;
using console_App;
using static System.Windows.Forms.LinkLabel;
using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace for the application behaviour
namespace WinFormsApp_SM
{
    public partial class Form1 : Form
    {
        ProgramSM program = new ProgramSM();

        public static string[] lines;
        public Form1()
        {
            InitializeComponent();

        }

        public static string startCity;
        public static string destinationCity;
        public static string searchMethod;

        public static List<string> statusRoute = new List<string>();
        public static List<string> statusVisited = new List<string>();
        string route;
        string visited;
        private void button_search_Click(object sender, EventArgs e)
        {
            statusRoute.Clear();
            statusVisited.Clear();
            CityGraph.arrayScale = 0;

            // Clear the TextBox and reset the ProgressBar
            progressBar1.Value = 0;
            rtb_route.Clear();

            // Get the selected parameter from the ComboBox
            startCity = comboBox_startCity.SelectedItem.ToString();
            destinationCity = comboBox_endCity.SelectedItem.ToString();
            searchMethod = comboBox_method.SelectedItem.ToString();
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            program.mainProgram();
            watch.Stop();

            for (int i = 1; i <= 100; i++)
            {

                progressBar1.Value = i;

                // Allow the UI to update
                Application.DoEvents();
            }

            route = string.Join('>', statusRoute);
            rtb_route.Text = route;

            visited = string.Join('>', statusVisited);
            rtb_visited.Text = visited;

            int roundDist = Convert.ToInt32(Math.Floor(CityGraph.distanceCalculated));

            textBox_totalTime.Text =  watch.ElapsedMilliseconds.ToString() + " ms";
            textBox_distance.Text = "Rounded : " + roundDist + " Km";
            textBox_arraySize.Text = CityGraph.arrayScale.ToString();

        }

    }

}

//namespace of the search method programs
namespace console_App
{
    // Define a class to represent a City with a name, latitude, and longitude.
    class City
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    // Define a class to read coordinates from a CSV file and calculate distances between them.
    class coordinatesCSV
    {
        // Method to read coordinates from a CSV file and return them as a list of strings.
        public List<string> coordinatesString()
        {
            // Read all lines from a CSV file located at the specified path.
            string[] csvCoordinates = System.IO.File.ReadAllLines(@"assets\coordinates.csv");

            var longLat = new List<string>();

            // Loop through each line in the CSV file.
            for (int i = 0; i < csvCoordinates.Length; i++)
            {
                // Split the CSV line into an array based on commas.
                string[] csvCoordinatesArray = csvCoordinates[i].Split(',');

                // Add city, longitude, and altitude to the list.
                longLat.Add(csvCoordinatesArray[0]); // City
                longLat.Add(csvCoordinatesArray[1]); // Longitude
                longLat.Add(csvCoordinatesArray[2]); // Latitude
            }

            return longLat;
        }

        // Method to calculate the distance between two sets of latitude and longitude coordinates using the Haversine formula.
        public double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double EarthRadius = 6371; // Radius of the Earth in kilometers

            // Convert latitude and longitude from degrees to radians.
            double lat1Rad = lat1 * Math.PI / 180;
            double lon1Rad = lon1 * Math.PI / 180;
            double lat2Rad = lat2 * Math.PI / 180;
            double lon2Rad = lon2 * Math.PI / 180;

            // Calculate the differences in latitude and longitude.
            double deltaLat = lat2Rad - lat1Rad;
            double deltaLon = lon2Rad - lon1Rad;

            // Haversine formula to calculate distance.
            double a = Math.Pow(Math.Sin(deltaLat / 2), 2) +
                       Math.Cos(lat1Rad) * Math.Cos(lat2Rad) * Math.Pow(Math.Sin(deltaLon / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // Calculate the distance using the Earth's radius and the Haversine formula.
            double distance = EarthRadius * c;

            // Return the calculated distance.
            return distance;
        }
    }
    class CityGraph
    {
        private Dictionary<string, List<string>> adjacencyList;
        private Dictionary<string, City> cityInfo;

        public CityGraph()
        {
            adjacencyList = new Dictionary<string, List<string>>();
            cityInfo = new Dictionary<string, City>();
        }

        // Method to add a city to the graph with its name, latitude, and longitude
        public void AddCity(string cityName, double latitude, double longitude)
        {
            // Add city to adjacency list if not already present
            if (!adjacencyList.ContainsKey(cityName))
                adjacencyList[cityName] = new List<string>();

            // Store city information in the city info dictionary
            cityInfo[cityName] = new City { Name = cityName, Latitude = latitude, Longitude = longitude };
        }

        public void AddConnection(string city1, string city2)
        {
            // Add connections between city1 and city2 in both directions
            if (adjacencyList.ContainsKey(city1) && adjacencyList.ContainsKey(city2))
            {
                adjacencyList[city1].Add(city2);
                adjacencyList[city2].Add(city1); // Assuming it's a bidirectional connection
            }
        }

        // Method to find a route between two cities using various search algorithms
        public List<string> FindRoute(string startCity, string endCity, string method)
        {
            string chooseMethod = method;
            switch (chooseMethod)
            {
                case "Brute-Force Approach (Recursive)":
                    if (!adjacencyList.ContainsKey(startCity) || !adjacencyList.ContainsKey(endCity))
                        return null;

                    List<string> routeBFM = new List<string> { startCity };

                    // Call a recursive function to find a route from startCity to endCity
                    if (FindRouteRecursive(startCity, endCity, routeBFM))
                    {
                        // Calculate the distance of the route and visited then store it
                        DistanceList(listBFM);

                        return routeBFM; 
                    }
                    else
                    {
                        return null;

                    }

                    //Unused brute force permutation approach
                    {
                        //if (!adjacencyList.ContainsKey(startCity) || !adjacencyList.ContainsKey(endCity))
                        //    return null; // Start or end city not found in the graph

                        //List<string> cities = new List<string>(adjacencyList.Keys);
                        //List<string> shortestRoute = null;
                        //double shortestDistance = double.MaxValue;
                        //int a = 0;

                        //foreach (var permutation in GetPermutations(cities))
                        //{
                        //    double totalDistance = CalculateTotalDistance(permutation);
                        //    a++;
                        //    //Console.WriteLine("Node : " + a);
                        //    //Console.WriteLine("total Distance : " + totalDistance);

                        //    if (totalDistance < shortestDistance)
                        //    {
                        //        //DistanceEnum(permutation);
                        //        shortestDistance = totalDistance;
                        //        shortestRoute = permutation.ToList();
                        //        //for (int i = 0; i < shortestRoute.Count; i++)
                        //        //    Console.WriteLine("Shortest Route :" + shortestRoute);
                        //    }
                        //}
                        //watch.Stop();
                        //foreach (var city in cities)
                        //{
                        //    Form1.statusVisited.Add(city);
                        //}
                        //return shortestRoute;
                    }
                    break; //BFM
                case "Depth-First Search (DFS)":
                    List<string> visited = new List<string>();
                    List<string> route = new List<string>();

                    // Call the DFS function to find a route from startCity to endCity
                    if (DFS(startCity, endCity, visited, route))
                    {
                        return route;
                    }
                    else
                    {
                        return null; // No route found
                    }
                    break; //DFS
                case "Breadth-First Search (BFS)":
                    if (!adjacencyList.ContainsKey(startCity) || !adjacencyList.ContainsKey(endCity))
                        return null;

                   
                    Dictionary<string, string> parentMap = new Dictionary<string, string>();

                    // Create a queue to perform BFS
                    Queue<string> queue = new Queue<string>();
                    queue.Enqueue(startCity);

                   
                    parentMap[startCity] = null;

                    while (queue.Count > 0)
                    {
                        // Dequeue the current city from the queue
                        string currentCity = queue.Dequeue();
                        if (currentCity == endCity)
                        { 
                            List<string> routeBFS = ReconstructRoute(parentMap, startCity, endCity);
                            return routeBFS;
                        }

                        // Explore neighbors of the current city
                        foreach (string neighbor in adjacencyList[currentCity])
                        {
                            // Check if the neighbor has not been visited
                            if (!parentMap.ContainsKey(neighbor))
                            {
                                // Enqueue the neighbor for further exploration
                                queue.Enqueue(neighbor);

                                // Enqueue the neighbor into a list for distance calculation
                                listBFS.Enqueue(neighbor);

                                // Calculate and update the distances of visited cities
                                DistanceQueue(listBFS);

                                // Set the parent of the neighbor as the current city
                                parentMap[neighbor] = currentCity;
                            }
                        }
                    }
                    break; //BFS
                case "Best-First Search":
                    if (!adjacencyList.ContainsKey(startCity) || !adjacencyList.ContainsKey(endCity))
                        return null;

                    PriorityQueue<Node> openList = new PriorityQueue<Node>();
                    HashSet<string> closedSet = new HashSet<string>();

                    // Enqueue the starting city as the initial node into the priority queue
                    openList.Enqueue(new Node(startCity, null, 0, CalculateHeuristic(startCity, endCity)), 0);

                    while (openList.Count > 0)
                    {
                        // Dequeue the node with the highest priority (lowest distance)
                        Node currentNode = openList.Dequeue();

                        if (currentNode.City == endCity)
                        {
                            // Reconstruct the route from the currentNode
                            List<string> routeH = ReconstructRouteH(currentNode);

                            return routeH;
                        }

                        // Add the current city to the closed set to mark it as visited
                        closedSet.Add(currentNode.City);

                        // Calculate distances of visited cities for analysis
                        DistanceHash(closedSet);

                        // Explore neighbors of the current city by iterating through the adjacency list
                        foreach (string neighbor in adjacencyList[currentNode.City])
                        {
                            // Check if the neighbor is not in the closed set (not visited)
                            if (!closedSet.Contains(neighbor))
                            {
                                // Calculate the priority (distance) from the current city to the neighbor
                                double priority = CalculateDistance(currentNode.City, neighbor);

                                // Enqueue the neighbor as a new node with its priority
                                openList.Enqueue(new Node(neighbor, currentNode, priority, 0), 0);
                            }
                        }
                    }

                    return null; // No route found
                    break; //Best
                case "ID-DFS":
                    if (!adjacencyList.ContainsKey(startCity) || !adjacencyList.ContainsKey(endCity))
                    {
                        return null;
                    }

                    // Create a set to store visited cities across multiple depth levels
                    HashSet<string> visitedIDTotal = new HashSet<string>();

                    // Iterate through different depth limits for increasing search depth
                    for (int depthLimit = 0; depthLimit < adjacencyList.Count; depthLimit++)
                    {
                        // Create a new set to store visited cities at the current depth level
                        HashSet<string> visitedID = new HashSet<string>();

                        // Perform ID-DFS search with the specified depth limit
                        bool goalFound = IDDFS(startCity, endCity, depthLimit, visitedID);

                        if (goalFound)
                        {
                            // Reconstruct the route
                            List<string> routeID = new List<string> { startCity };
                            routeID.AddRange(visitedID);

                            return routeID;
                        }
                    }

                    return null; // No route found
                    break; //ID-DFS
                case "A* Search":
                    if (!adjacencyList.ContainsKey(startCity) || !adjacencyList.ContainsKey(endCity))
                        return null; // Start or end city not found in the graph

                    PriorityQueue<Node> openListA = new PriorityQueue<Node>();
                    HashSet<string> closedSetA = new HashSet<string>();

                    openListA.Enqueue(new Node(startCity, null, 0, CalculateHeuristic(startCity, endCity)), 0);

                    while (openListA.Count > 0)
                    {
                        Node currentNode = openListA.Dequeue();

                        if (currentNode.City == endCity)
                        {
                            List<string> routeA = ReconstructRouteH(currentNode);

                            return routeA;
                        }

                        closedSetA.Add(currentNode.City);
                        DistanceHash(closedSetA);

                        foreach (string neighbor in adjacencyList[currentNode.City])
                        {
                            if (!closedSetA.Contains(neighbor))
                            {
                                // Calculate the cost from the start to the neighbor through the current node
                                double cost = currentNode.Cost + CalculateHeuristic(currentNode.City, neighbor);

                                // Calculate the heuristic estimate from the neighbor to the destination
                                double heuristic = CalculateHeuristic(neighbor, endCity);

                                // Calculate the priority (f(n) = g(n) + h(n)) for the neighbor
                                double priority = cost + heuristic;

                                // Enqueue the neighbor with its updated cost and priority
                                openListA.Enqueue(new Node(neighbor, currentNode, cost, heuristic), priority);
                            }
                        }
                    }

                    return null;
                    break; //A*
                default:
                    return null;
                    break;
            }
            return null;
        }



        public static double distanceCalculated = 0;
        public static List<string> visitedCalculated = new List<string>();
        public static int arrayScale = 0;

        //Variable to store the list of visited city in each of methods
        Queue<string> listBFS = new Queue<string>();
        List<string> listBFM = new List<string>();
        HashSet<string> listIDDFS = new HashSet<string>();

        //Calculate the distance nodes to nodes, each visited nodes and array scale in total (sum)
        public void DistanceQueue(Queue<string> visited)
        {
            int a = 0;

            var visitedDistance = new List<double>();
            var routeDistance = new List<double>();
            distanceCalculated = 0;

            double lon1 = 0;
            double lat1 = 0;
            double distanceBetweenCities = 0;

            coordinatesCSV coor = new coordinatesCSV();
            List<string> coorArray = coor.coordinatesString();


            //Console.WriteLine("\nVisited City : ");

            foreach (string city in visited)
            {
                a++;
                //Console.WriteLine($"{a}. {city}");
                Form1.statusVisited.Add(" " + a + ". " + city + " ");
                int index = coorArray.FindIndex(a => a.Contains(city));


                lat1 = Convert.ToDouble(coorArray[index + 1]);
                lon1 = Convert.ToDouble(coorArray[index + 2]);

                visitedDistance.Add(lat1);
                visitedDistance.Add(lon1);

            }

            for (int i = 0; i < visitedDistance.Count - 3; i += 2)
            {

                distanceBetweenCities = coor.CalculateDistance(visitedDistance[i], visitedDistance[i + 1], visitedDistance[i + 2], visitedDistance[i + 3]);
                distanceCalculated += distanceBetweenCities;

            }
            arrayScale += visited.Count;

            //Console.WriteLine("---Total Scale Array : " + scaleArray + " ---");
            //Console.WriteLine("---Total Visited Distance : " + distanceCalculated + " Km---");
        }
        public void DistanceList(List<string> visited)
        {
            int a = 0;

            var visitedDistance = new List<double>();
            var routeDistance = new List<double>();
            distanceCalculated = 0;

            double lon1 = 0;
            double lat1 = 0;
            double distanceBetweenCities = 0;

            coordinatesCSV coor = new coordinatesCSV();
            List<string> coorArray = coor.coordinatesString();


            //Console.WriteLine("\nVisited City : ");

            foreach (string city in visited)
            {
                a++;
                //Console.WriteLine($"{a}. {city}");
                Form1.statusVisited.Add(" " + a + ". " + city + " ");
                int index = coorArray.FindIndex(a => a.Contains(city));


                lat1 = Convert.ToDouble(coorArray[index + 1]);
                lon1 = Convert.ToDouble(coorArray[index + 2]);

                visitedDistance.Add(lat1);
                visitedDistance.Add(lon1);

            }

            for (int i = 0; i < visitedDistance.Count - 3; i += 2)
            {

                distanceBetweenCities = coor.CalculateDistance(visitedDistance[i], visitedDistance[i + 1], visitedDistance[i + 2], visitedDistance[i + 3]);
                distanceCalculated += distanceBetweenCities;

            }
            arrayScale += visited.Count;
            //Console.WriteLine("---Total Scale Array : " + scaleArray + " ---");
            //Console.WriteLine("---Total Visited Distance : " + distanceCalculated + " Km---");
        }
        public void DistanceHash(HashSet<string> visited)
        {
            int a = 0;

            var visitedDistance = new List<double>();
            var routeDistance = new List<double>();
            distanceCalculated = 0;

            double lon1 = 0;
            double lat1 = 0;
            double distanceBetweenCities = 0;

            coordinatesCSV coor = new coordinatesCSV();
            List<string> coorArray = coor.coordinatesString();


            //Console.WriteLine("\nVisited City : ");

            foreach (string city in visited)
            {
                a++;
                //Console.WriteLine($"{a}. {city}");
                Form1.statusVisited.Add(" " + a + ". " + city + " ");
                int index = coorArray.FindIndex(a => a.Contains(city));


                lat1 = Convert.ToDouble(coorArray[index + 1]);
                lon1 = Convert.ToDouble(coorArray[index + 2]);

                visitedDistance.Add(lat1);
                visitedDistance.Add(lon1);

            }

            for (int i = 0; i < visitedDistance.Count - 3; i += 2)
            {

                distanceBetweenCities = coor.CalculateDistance(visitedDistance[i], visitedDistance[i + 1], visitedDistance[i + 2], visitedDistance[i + 3]);
                distanceCalculated += distanceBetweenCities;

            }
            arrayScale += visited.Count;
            //Console.WriteLine("---Total Scale Array : " + scaleArray + " ---");
            //Console.WriteLine("---Total Visited Distance : " + distanceCalculated + " Km---");
        }

        //public void DistanceEnum(IEnumerable<string> visited)
        //{
        //    int a = 0;
        //    int b = 0;

        //    var visitedDistance = new List<double>();
        //    var routeDistance = new List<double>();
        //    distanceCalculated = 0;
        //    arrayScale = 0;

        //    double lon1 = 0;
        //    double lat1 = 0;
        //    double distanceBetweenCities = 0;

        //    coordinatesCSV coor = new coordinatesCSV();
        //    List<string> coorArray = coor.coordinatesString();


        //    //Console.WriteLine("\nVisited City : ");

        //    foreach (string city in visited)
        //    {
        //        a++;
        //        //Console.WriteLine($"{a}. {city}");
        //        int index = coorArray.FindIndex(a => a.Contains(city));
        //        //index += 3;

        //        lat1 = Convert.ToDouble(coorArray[index + 1]);
        //        lon1 = Convert.ToDouble(coorArray[index + 2]);

        //        visitedDistance.Add(lat1);
        //        visitedDistance.Add(lon1);

        //    }

        //    for (int i = 0; i < visitedDistance.Count - 3; i += 2)
        //    {

        //        distanceBetweenCities = coor.CalculateDistance(visitedDistance[i], visitedDistance[i + 1], visitedDistance[i + 2], visitedDistance[i + 3]);
        //        distanceCalculated += distanceBetweenCities;

        //    }
        //    arrayScale = visitedDistance.Count;
        //    //Console.WriteLine("---Total Scale Array : " + scaleArray + " ---");
        //    //Console.WriteLine("---Total Visited Distance : " + distanceCalculated + " Km---");
        //}

        
        // Recursively finds a route from the current city to the end city using a depth-first search.
        private bool FindRouteRecursive(string currentCity, string endCity, List<string> route) // Recursively finds a route from the current city to the end city using a depth-first search.
        {
            int index = 0;
            if (currentCity == endCity)
                return true; // Goal found

            foreach (string neighbor in adjacencyList[currentCity])
            {
                index++;
                if (!route.Contains(neighbor))
                {
                    route.Add(neighbor);
                    listBFM.Add(neighbor); //Add visited cities to list for output

                    if (FindRouteRecursive(neighbor, endCity, route))
                        return true; // Goal found in this branch
                    route.Remove(neighbor); // Backtrack
                }
            }

            return false; // Goal not found in this branch
        }

        private bool DFS(string currentCity, string endCity, List<string> visited, List<string> route)
        {
            visited.Add(currentCity);
            route.Add(currentCity);
            DistanceList(visited);

            if (currentCity == endCity)
            {

                return true; // Route found
            }

            foreach (string neighbor in
                adjacencyList[currentCity])
            {
                if (!visited.Contains(neighbor))
                {
                    if (DFS(neighbor, endCity, visited, route))
                    {

                        return true; // Route found
                    }
                }
            }

            route.RemoveAt(route.Count - 1); // Backtrack
            return false; // No route found
        } // Performs a depth-first search to find a route from the current city to the end city.
        private bool IDDFS(string currentCity, string endCity, int depthLimit, HashSet<string> visited)
        {
            if (currentCity == endCity)
            {
                visited.Add(currentCity);
                
                return true; // Goal found
            }

            if (depthLimit <= 0)
                return false; // Reached depth limit

            visited.Add(currentCity);


            foreach (string neighbor in adjacencyList[currentCity])
            {
                if (!visited.Contains(neighbor))
                {
                    if (IDDFS(neighbor, endCity, depthLimit - 1, visited))
                    {
                        return true; // Goal found in a deeper level
                    }

                }
            }

            listIDDFS.Add(currentCity);
            DistanceHash(listIDDFS);
            visited.Remove(currentCity); // Backtrack

            return false;
        } // Performs an iterative deepening depth-first search to find a route from the current city to the end city with a depth limit.
        private List<string> ReconstructRoute(Dictionary<string, string> visited, string startCity, string endCity)
        {
            List<string> route = new List<string>();
            string currentCity = endCity;

            while (currentCity != null)
            {
                route.Insert(0, currentCity);
                currentCity = visited[currentCity];
            }

            return route;
        }
        private List<string> ReconstructRouteH(Node currentNode)
        {
            List<string> route = new List<string>();
            while (currentNode != null)
            {
                route.Insert(0, currentNode.City);
                currentNode = currentNode.Parent;
            }
            return route;
        }
       
        private double CalculateHeuristic(string city, string endCity)
        {
            if (cityInfo.ContainsKey(city) && cityInfo.ContainsKey(endCity))
            {
                double lat1 = cityInfo[city].Latitude;
                double lon1 = cityInfo[city].Longitude;
                double lat2 = cityInfo[endCity].Latitude;
                double lon2 = cityInfo[endCity].Longitude;

                const double EarthRadius = 6371; // Earth's radius in kilometers
                double lat1Rad = DegreesToRadians(lat1);
                double lat2Rad = DegreesToRadians(lat2);
                double deltaLat = DegreesToRadians(lat2 - lat1);
                double deltaLon = DegreesToRadians(lon2 - lon1);

                double a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                           Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                           Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

                double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

                // Distance in kilometers
                double distance = EarthRadius * c;
                return distance;
            }
            else
            {
                return 0; // No heuristic information available
            }
        } //Method to calculate heuristic-based method
        private double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        } //to convert latitude and longitude from degrees to radians
        private double CalculateDistance(string city1, string city2)
        {
            if (cityInfo.ContainsKey(city1) && cityInfo.ContainsKey(city2))
            {
                double lat1 = cityInfo[city1].Latitude;
                double lon1 = cityInfo[city1].Longitude;
                double lat2 = cityInfo[city2].Latitude;
                double lon2 = cityInfo[city2].Longitude;

                const double EarthRadius = 6371; // Earth's radius in kilometers
                double lat1Rad = DegreesToRadians(lat1);
                double lat2Rad = DegreesToRadians(lat2);
                double deltaLat = DegreesToRadians(lat2 - lat1);
                double deltaLon = DegreesToRadians(lon2 - lon1);

                double a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                           Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                           Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

                double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

                // Distance in kilometers
                double distance = EarthRadius * c;
                return distance;
            }
            else
            {
                return 0; // No distance information available
            }
        } //Calculate distance between cities

        //Method for brute force permutations (it takes forever)
        //private IEnumerable<IEnumerable<string>> GetPermutations(List<string> cities)
        //{
        //    if (cities.Count <= 1)
        //    {
        //        yield return cities;
        //    }
        //    else
        //    {
        //        foreach (var city in cities)
        //        {
        //            var remainingCities = cities.Except(new[] { city }).ToList();
        //            foreach (var permutedCities in GetPermutations(remainingCities))
        //            {

        //                yield return new[] { city }.Concat(permutedCities);
        //            }
        //        }
        //    }
        //}

        //private double CalculateTotalDistance(IEnumerable<string> route)
        //{
        //    double totalDistance = 0;

        //    using (var routeEnumerator = route.GetEnumerator())
        //    {
        //        if (!routeEnumerator.MoveNext())
        //        {
        //            return 0;
        //        }

        //        string currentCity = routeEnumerator.Current;

        //        while (routeEnumerator.MoveNext())
        //        {
        //            string nextCity = routeEnumerator.Current;
        //            totalDistance += CalculateDistance(currentCity, nextCity);
        //            currentCity = nextCity;
        //        }

        //        // Complete the loop by returning to the starting city
        //        totalDistance += CalculateDistance(currentCity, route.First());
        //    }

        //    return totalDistance;
        //}
        //private void PermuteCities(string startCity, string endCity, List<string> currentPath, ref List<string> shortestPath, ref double shortestDistance)
        //{
        //    if (currentPath.Count == adjacencyList.Count)
        //    {
        //        // All cities have been visited; check if it forms a valid path
        //        if (currentPath[currentPath.Count - 1] == endCity)
        //        {
        //            double distance = CalculatePathDistance(currentPath);
        //            if (distance < shortestDistance)
        //            {
        //                shortestDistance = distance;
        //                shortestPath = new List<string>(currentPath);

        //            }
        //        }
        //        return;
        //    }

        //    foreach (string neighbor in adjacencyList[startCity])
        //    {
        //        if (!currentPath.Contains(neighbor))
        //        {
        //            currentPath.Add(neighbor);
        //            listBFM.Add(neighbor);
        //            PermuteCities(neighbor, endCity, currentPath, ref shortestPath, ref shortestDistance);
        //            currentPath.Remove(neighbor);
        //        }
        //    }
        //}
        //private double CalculatePathDistance(List<string> path)
        //{
        //    double distance = 0;
        //    for (int i = 0; i < path.Count - 1; i++)
        //    {
        //        distance += CalculateDistance(path[i], path[i + 1]);
        //    }
        //    return distance;
        //}

    }

   // Represents a node in a graph used for pathfinding algorithms.
    class Node
    {
        public string City { get; }
        public Node Parent { get; }
        public double Cost { get; }
        public double Heuristic { get; }

        public Node(string city, Node parent, double cost, double heuristic)
        {
            City = city;
            Parent = parent;
            Cost = cost;
            Heuristic = heuristic;
        }
    }

    //Represents a priority queue data structure used in pathfinding algorithms.
    class PriorityQueue<T>
    {
        private List<T> elements;
        private List<double> priorities;

        public int Count => elements.Count;

        public PriorityQueue()
        {
            elements = new List<T>();
            priorities = new List<double>();
        }

        public void Enqueue(T item, double priority)
        {
            int index = 0;
            while (index < priorities.Count && priority > priorities[index])
            {
                index++;

            }

            elements.Insert(index, item);
            priorities.Insert(index, priority);
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty.");

            T item = elements[0];
            elements.RemoveAt(0);
            priorities.RemoveAt(0);
            return item;
        }
    }


    class ProgramSM
    {
        public char continueProg;

        public void mainProgram()
        {
            CityGraph graph = new CityGraph();

            // Read city adjacency pairs from a text file
            string[] lines = File.ReadAllLines(@"assets\Adjacencies.txt");
            foreach (string line in lines)
            {
                string[] cities = line.Split(' ');
                if (cities.Length == 2)
                {
                    string city1 = cities[0].Trim();
                    string city2 = cities[1].Trim();
                    graph.AddCity(city1, 0, 0);
                    graph.AddCity(city2, 0, 0);
                    graph.AddConnection(city1, city2);
                }
            }

            // Open and read the coordinates data from a CSV file using CsvHelper.
            using (var reader = new StreamReader(@"assets\coordinates.csv"))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                // Parse the CSV records into City objects and add them to the graph.
                var records = csv.GetRecords<City>();
                foreach (var city in records)
                {
                    graph.AddCity(city.Name, city.Latitude, city.Longitude);
                }
            }

            // Find a route in the graph based on the specified search method and start/end cities.
            List<string> route = graph.FindRoute(Form1.startCity, Form1.destinationCity, Form1.searchMethod);
            if (route != null)
            {
                int i = 0;
                foreach (var city in route)
                {
                    i++;
                    Form1.statusRoute.Add(" " + i + ". " + city + " ");
                }

            }
            else
            {
                Form1.statusRoute.Add("No Route Found");

            }
        }
    }
}