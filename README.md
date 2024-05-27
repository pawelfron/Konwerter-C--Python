# Konwerter-C--Python
Projekt na przedmiot "Teoria kompilacji i kompilatory". Informatyka i Systemy Inteligentne, Akademia Górniczo-Hutnicza w Krakowie.

# Założenia projektu
Projekt jest aplikacją okienkową, umożliwiającą konwertowanie kodu napisanego w uproszczonym wariancie języka C, do kodu Pythona.

# Implementacja
Konwerter jest napisany w C#, z użyciem narzędzia [ANTLR4](https://www.antlr.org/index.html) oraz [Windows Forms](https://learn.microsoft.com/pl-pl/dotnet/desktop/winforms/overview/?view=netdesktop-8.0).

# Przetwarzany język
Język przetwarzany przez konwerter jest zdefiniowany przez dołączoną do projektu [gramatykę](CGrammar.g4). Najważniejsze różnice względem oryginalnego C to:
* brak instrukcji `switch` oraz `goto`,
* brak możliwości deklaracji kilku zmiennych w jednej lini, np. `int a, *b;`,
* brak wskaźników do funkcji,
* brak instrukcji preprocesora, z wyjątkiem `#include`,
* brak możliwości deklaracji unii, enumeracji i `typedef`,
* brak następujących specyfikatorów: `register`, `static`, `extern`, `volataile`, `restrict`, `inline`,
* brak następujących operatorów: `++`, `--`, `~`, `<<`, `>>`, `&`, `|`, `^`, `<<=`, `>>=`, `&=`, `|=`, `^=`, `? :`, `sizeof`.

# Autorzy
Paweł Froń, Jakub Grzyb
