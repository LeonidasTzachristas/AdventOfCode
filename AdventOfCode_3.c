#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char jolts[200][120];
    int i=0;

/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
    /* File open */
    FILE *file;
    file = fopen("batteries.txt", "r");
    if (file==NULL) {
        printf("Cannot Open File\n");
        exit(1);
    }

    /* Copy txt to jolt[200][] array as string */
    while (!feof(file)) {
        fgets(jolts[i], 120, file);
        if (i!=199) {                               //last digit not followed by \n
            jolts[i][strlen(jolts[i])-1] = '\0';
        }
        i++;
    }

    fclose(file);
/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - */


    // printf("%d\n\n", strlen(jolts[0]));
    for (i=0; i<200; i++) {         //print jolt array
        printf("%s\n", jolts[i]);
    }
    printf("\n\n");


    int k, dig1, dig2, total=0;
    char max;
    int metra=0;
    int a, b;

    for (i=0; i<200; i++) {                             //1st loop to iterate jolst[200]
        max = jolts[i][0];
        dig1 = 0;
        for (k=0; k<100-2; k++) {          //2nd loop to find max1
            if (jolts[i][k]>max) {
                max = jolts[i][k];
                dig1 = k;
            }
        }

        max = jolts[i][dig1+1];
        dig2 = dig1;
        for (k=dig1+2; k<100-1; k++) {       //3rd loop to find max2
            if (jolts[i][k]>max) {
                max = jolts[i][k];
                dig2 = k;
            }
        }

        printf("%c%c\t", jolts[i][dig1], jolts[i][dig2]);

        a = (jolts[i][dig1]-'0')*10;
        b = jolts[i][dig2]-'0';
        printf("%d\n", a + b);
        total += (a + b);
        metra++;
    }

    printf("\n%d\n", total);
    printf("\n%d\n", metra);

    return 0;
}