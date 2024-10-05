#include "printFunctions.h"

void printMenu(){
    printf("\n------ Spiral Matrix Generator ------\n");
    printf("0 - Guide\n");
    printf("1 - Generate\n");
    printf("2 - Save\n");
    printf("3 - Load\n");
    printf("4 - Print\n");
    printf("5 - Exit\n");
    printf("-------------------------------------\n");
    
}

void printMatrix(Matrix matrix){
    if (matrix.exists != false){
        int max = matrix.size * matrix.size;
        char str[5];
        sprintf(str, "%d", max);
        int maxlength = strlen(str);
        printf("\n");
        for (int i = 0 ; i < matrix.size ; i++){
            for (int j = 0 ; j < matrix.size ; j++){
                sprintf(str, "%d", matrix.matrix[i][j]);
                for (unsigned int k = 0 ; k <= maxlength - strlen(str) ; k++){
                    printf(" ");
                }
                printf("%d", matrix.matrix[i][j]);
            }
            printf("\n");
        }
    }else{
        printf("Nincs generalt/betoltott matrix!\n");
    }
}