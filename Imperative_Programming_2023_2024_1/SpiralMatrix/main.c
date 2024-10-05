//Farádi Bálint - Imperatív programozás beadandó - 2023.12.30
#include "main.h"

int main(){
    bool run = true;
    Matrix matrix;
    matrix.exists = false;
    matrix.matrix = NULL;
    while (run){
        Choice* userInput = malloc(sizeof(Choice));
        *userInput = readChoice();
        switch (*userInput){
        case Guide:
            callGuide();
            break;
        case Generate:
            callGenerateMatrix(&matrix);
            break;
        case Save:
            saveMatrix(&matrix);
            break;
        case Load:
            loadMatrix(&matrix);
            break;
        case Print:
            printMatrix(matrix);
            break;
        case Exit:
            run = false;
            break;
        case NUL:
            printf("Hibas ertek! Probald ujra!\n");
            break;
        default:
            printf("Programhiba: Le nem kezelt ertek\n");
            break;
        }
        free(userInput);
    }
    freeMemoryAllocations(&matrix);
    printf("A program vege!");
    return 0;
}

void callGuide(){
    printf("------ Spiral Matrix Generator GUIDE------\n");
    printf("Lehetosegek:\nN x N spiralmatrix generalasa (meret - irany - forgas) alapjan- 1\nGeneralt matrix fileba mentese - 2\nMatrix filebol memoriaba toltese - 3\nMemoriaban levo matrix megjelenitese a kepernyon - 4\nKilepes a programbol - 5\n");
}

void freeMemoryAllocations(Matrix* matrix){
    if (matrix -> matrix != NULL){
        for (int i = 0 ; i < matrix -> size ; i++){
        free(matrix -> matrix[i]);
    }
    free(matrix -> matrix);
    matrix -> matrix = NULL;
    }
}