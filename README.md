# Konwerter-C--Python
Projekt na przedmiot "Teoria kompilacji i kompilatory". Informatyka i Systemy Inteligentne, Akademia Górniczo-Hutnicza w Krakowie.

# Założenia projektu
Projekt jest aplikacją okienkową, umożliwiającą konwertowanie kodu napisanego w uproszczonym wariancie języka C, do kodu Pythona.

# Implementacja
Konwerter jest napisany w C#, z użyciem narzędzia [ANTLR4](https://www.antlr.org/index.html) oraz Windows Forms.

# Przetwarzany język
Język przetwarzany przez konwerter jest zdefiniowany przez dołączoną do projektu [gramatykę](CGrammar.g4). Najważniejsze różnice względem oryginalnego C to:
* brak instrukcji `switch` oraz `goto`,
* brak możliwości deklaracji kilku zmiennych w jednej lini, np. `int a, *b;`,
* brak wskaźników do funkcji,
* brak instrukcji preprocesora, z wyjątkiem `#include`,
* brak możliwości deklaracji unii, enumeracji i `typedef`,
* brak następujących specyfikatorów: `register`, `static`, `extern`, `volataile`, `restrict`, `inline`,
* brak następujących operatorów: `++`, `--`, `~`, `<<`, `>>`, `&`, `|`, `^`, `<<=`, `>>=`, `&=`, `|=`, `^=`, `? :`, `sizeof`.

# Krótka instrukcja obsługi
Aby uruchomić aplikację, należy:
1. Sklonować repozytorium, przejść do katalogu głównego i wykonać polecenie dotnet run.
2. Kod w C, który chcemy przekonwertować, należy wpisać do pola tekstowego po lewej stronie i wcisnąć przycisk *Przekonwertuj i wykonaj*.
3. W środkowym polu pojawi się wynikowy kod w Pythonie, a po prawej efekt wykonania aplikacji.


# Autorzy
Paweł Froń, Jakub Grzyb
