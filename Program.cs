using NavalPlacementChallenge;
using NavalPlacementChallenge.Entities;

var title = @"
██████╗  ██████╗  █████╗ ████████╗     ██████╗  █████╗ ███╗   ███╗███████╗
██╔══██╗██╔═══██╗██╔══██╗╚══██╔══╝    ██╔════╝ ██╔══██╗████╗ ████║██╔════╝
██████╔╝██║   ██║███████║   ██║       ██║  ███╗███████║██╔████╔██║█████╗  
██╔══██╗██║   ██║██╔══██║   ██║       ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  
██████╔╝╚██████╔╝██║  ██║   ██║       ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗
╚═════╝  ╚═════╝ ╚═╝  ╚═╝   ╚═╝        ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝                                                                          
";

var description = "Bienvenido al juego de colocar tu nave barco";

Console.Clear();

var game = new Game(title, description);

List<Ship> ships =
[
    new Ship(5, "Portaaviones"),
    new Ship(4, "Acorazado"),
    new Ship(3, "Submarino"),
    new Ship(3, "Cruiser"),
    new Ship(2, "Destructor")
];


game.Run(ships);

Console.ReadKey();
Console.Clear();