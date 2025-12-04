#include <stdio.h>
#include <stdlib.h>
#include <string.h>

struct kwdikes
{
    char dir;
    int num;
};
struct kwdikes codika[4570];

int main()
{
    char codes[4570][5];
    int count=0, i=0;
    FILE* fptr;
    char rot[10];

    fptr = fopen("rotations.txt", "r");
    if (fptr==NULL) {
        printf("Error Opening Text");
        exit(1);
    }

    while (!feof(fptr)) {
        fgets(rot, 10, fptr);
        if (!feof(fptr)) {
            rot[strlen(rot)-1] = '\0';
            // puts(rot);
        }
        strcpy(codes[i], rot);
        count++;
        i++;
    }

    fclose(fptr);

    printf("Total count: %d", count);
    // for (i=0; i<4570; i++) {
    //     printf("%s\n", codes[i]);
    // }


/* Metatropi tou pinaka rot se struct  */
    int noumero = 0;
    for (int j=0; j<4570; j++) {
        codika[j].dir = codes[j][0];
        noumero = 0;
        for (int k = 1; codes[j][k] != '\0'; k++) {
            if (codes[j][k] >= 48 && codes[j][k] <= 57) {
                noumero = noumero * 10 + (codes[j][k] - 48);
            }
            else {
                break;
            }
        }
        codika[j].num = noumero;
    }

    for (i=0; i<4570; i++) {
        printf("%c\t%d\t%d\n", codika[i].dir, codika[i].num, i);
    }

    int perasmata=0;
    int posa=0;
    int point=50;
    // for (i=0; i<4570; i++) {
    //     if (codika[i].dir=='R') {
    //         point += codika[i].num;
    //         while (point>99) {
    //             perasmata++;
    //             point -= 100;
    //         }
    //     }
    //     if (codika[i].dir=='L') {
    //         point -= codika[i].num;
    //         while (point<0) {
    //             perasmata++;
    //             point += 100;
    //         }
    //     }
    //     if (point==0) {
    //         posa++;
    //     }
    // }
    for (i=0; i<4570; i++) {
        if (codika[i].dir=='R') {
            while (codika[i].num>0) {
                point++;
                if (point>99) {
                    point -= 100;
                }
                if (point==0) {
                    perasmata++;
                }
                codika[i].num--;
            }
        }
        if (codika[i].dir=='L') {
            while (codika[i].num>0) {
                point--;
                if (point<0) {
                    point += 100;
                }
                if (point==0) {
                    perasmata++;
                }
                codika[i].num--;
            }
        }
        if (point==0) {
            posa++;
        }
    }

    printf("%d\n", posa);
    printf("%d\n", perasmata);



    return 0;
}