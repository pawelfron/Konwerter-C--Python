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

# Przykład - kod z C do Pythona
```C
    #include<stdio.h>
    int fibb(int n) {
        if(n == 0) {
            return 0;
        }
        if(n == 1) {
            return 1;
        }
        int result = fibb(n-1) + fibb(n-2);
        printf("dla n=%d fibb=%d", n, result);
        return result;
    }

    int main() {
        int n = 7 + 3;
        int result = fibb(n); // hello there
        printf("\n\nWynik dla n = %d to %d\n", n, result);
    }
```
```python
    def printf(*args):
        s = args[0]
        for i in args[1:]:
            s = s.replace(s[s.find('%'):s.find('%')+2], str(i), 1)
        print(s)
    def fibb(n):
        if n==0:
            return 0
        if n==1:
            return 1
        result=fibb(n-1)+fibb(n-2)
        printf("dla n=%d fibb=%d",n,result)
        return result
    def main():
        n=7+3
        result=fibb(n)
        printf("\n\nWynik dla n = %d to %d\n",n,result)
    main()
```

# Autorzy
Paweł Froń, Jakub Grzyb
