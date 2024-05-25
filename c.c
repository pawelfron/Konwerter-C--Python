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