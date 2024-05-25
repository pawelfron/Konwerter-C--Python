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