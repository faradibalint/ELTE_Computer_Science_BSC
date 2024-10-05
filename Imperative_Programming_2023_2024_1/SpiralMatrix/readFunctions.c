#include "readFunctions.h"

Choice readChoice(){
    printMenu();
    char buffer[100];
    if (scanf("%99s",buffer) != EOF){
        if (strcmp(buffer, "0") == 0){
            return Guide;
        }else if(strcmp(buffer, "1") == 0){
            return Generate;
        }else if(strcmp(buffer, "2") == 0){
            return Save;
        }else if(strcmp(buffer, "3") == 0){
            return Load;
        }else if(strcmp(buffer, "4") == 0){
            return Print;
        }else if(strcmp(buffer, "5") == 0){
            return Exit;
        }else{
            return NUL;
        }
    }else{
        return NUL;
    }
}

void readProperties(Matrix_Properties* data){
    printf("Add meg a matrix meretet (1-20)\n");
    char n[30];
    while(scanf("%29s", n) == EOF || atoi(n)<1 || atoi(n)>20){
        printf("Hibas ertek! Elfogadhato ertekek: 1-20. Probald ujra!\n");
    }
    data -> size = atoi(n);
    printf("Add meg, hogy merre induljon a matrix (balra,fel,jobbra,le)\n");
    char nn[100];
    while(scanf("%99s", nn) == EOF || (strcmp(nn,"balra")!=0 && strcmp(nn,"fel")!=0 && strcmp(nn,"le")!=0 && strcmp(nn,"jobbra")!=0)){
        printf("Hibas ertek! Elfogadhato ertekek: balra,fel,jobbra,le. Probald ujra!\n");
    }
    if (strcmp(nn, "balra") == 0){
        data -> dir = balra;
    }else if (strcmp(nn, "fel") == 0){
        data -> dir = fel;
    }else if (strcmp(nn, "le") == 0){
        data -> dir = le;
    }else if (strcmp(nn, "jobbra") == 0){
        data -> dir = jobbra;
    }else{
        printf("Nincs egyezes\n");
    }
    char rot[20];
    printf("Add meg a matrix forgasi iranyat (cw,ccw)\n");
    while(scanf("%19s", rot) == EOF || (strcmp(rot,"cw")!=0 && strcmp(rot,"ccw")!=0)){
        printf("Hibas ertek! Elfogadhato ertekek: cw,ccw. Probald ujra!\n");
    }
    if (strcmp(rot,"cw")==0){
        data -> rotate = cw;
    }else if (strcmp(rot, "ccw") == 0){
        data -> rotate = ccw;
    }else{
        printf("Nincs egyezes\n");
    }
}