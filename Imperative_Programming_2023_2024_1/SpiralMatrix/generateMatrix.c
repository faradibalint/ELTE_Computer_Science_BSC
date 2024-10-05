#include "generateMatrix.h"

void callGenerateMatrix(Matrix* my_matrix){
    freeMemoryAllocations(my_matrix);
    Matrix_Properties* data = malloc(sizeof(Matrix_Properties));
    readProperties(data);
    my_matrix -> size = data -> size;
    my_matrix -> matrix = malloc(data -> size * sizeof(int*));
    for (int i = 0 ; i < data -> size ; i++){
        my_matrix -> matrix[i] = malloc(data -> size * sizeof(int));
    }
    //mátrix feltöltése
    fillMatrix(my_matrix, data);
    //save-hez a filenév összerakása
    char d;
    if(data -> dir == 0){
        d = 'b';
    }else if( data -> dir == 1){
        d = 'f';
    }else if( data -> dir == 2){
        d = 'j';
    }else if( data -> dir == 3){
        d = 'l';
    }else{
        printf("Nem talalhato ertek!\n");
    }

    char r[5];
    if (data -> rotate == 0){
        strcpy(r, "cw");
    }else if(data -> rotate == 1){
        strcpy(r, "ccw");
    }else{
        printf("Nem talalhato ertek!\n");
    }
    sprintf(my_matrix -> properties, "spiral%d%c%s.txt", data -> size, d , r);
    my_matrix -> exists = true;
    free(data);
}

void fillMatrix(Matrix* matrix, Matrix_Properties* data){
    if (matrix -> size % 2 != 0){
        int value = 1, x = (matrix -> size)/2, y = (matrix -> size)/2;
        matrix -> matrix[x][y] = value;
        for (int i = 1 ; i < matrix -> size ; i++){
            moveAndFill(i, &value, matrix -> matrix, &x, &y);
        }
        for (int i = 1 ; i < matrix -> size ; i++){
            x--;
            value++;
            matrix -> matrix[x][y] = value;
        }
        if (data -> rotate == 0){
            if(data -> dir == 0){
                for (int i = 0 ; i < 3 ; i++){
                    rotateMatrix(matrix -> matrix, matrix -> size);
                }
            }else if( data -> dir == 2){
                rotateMatrix(matrix -> matrix, matrix -> size);
            }else if( data -> dir == 3){
                for (int i = 0 ; i < 2 ; i++){
                    rotateMatrix(matrix -> matrix, matrix -> size);
                }
            }
        }else{
            if (data -> dir == 1){
                mirrorMatrix(matrix -> matrix, matrix -> size);
            }else if(data -> dir == 2){
                for (int i = 0 ; i < 3 ; i++){
                    rotateMatrix(matrix -> matrix, matrix -> size);
                }
                mirrorMatrix(matrix -> matrix, matrix -> size);
            }else if (data -> dir == 3){
                for (int i = 0 ; i < 2 ; i++){
                    rotateMatrix(matrix -> matrix, matrix -> size);
                }
                mirrorMatrix(matrix -> matrix, matrix -> size);

            }else{
                rotateMatrix(matrix -> matrix, matrix -> size);
                mirrorMatrix(matrix -> matrix, matrix -> size);
            }
        }
    }else{
        int value = 1, x = (matrix -> size)/2, y = ((matrix -> size)/2)-1;
        matrix -> matrix[x][y] = value;
        for (int i = 1 ; i < matrix -> size ; i++){
            moveAndFill(i, &value, matrix -> matrix, &x, &y);
        }
        for (int i = 1 ; i < matrix -> size ; i++){
            x++;
            value++;
            matrix -> matrix[x][y] = value;
        }
        if (data -> rotate == 0){
            if(data -> dir == 2){
                rotateMatrix(matrix -> matrix, matrix -> size);
            }else if( data -> dir == 3){
                for (int i = 0 ; i < 2 ; i++){
                    rotateMatrix(matrix -> matrix, matrix -> size);
                }
            }else if( data -> dir == 0){
                for (int i = 0 ; i < 3 ; i++){
                rotateMatrix (matrix -> matrix, matrix -> size);
                }
            }
        }else{
            if (data -> dir == 1){
                mirrorMatrix(matrix -> matrix, matrix -> size);
            }else if(data -> dir == 2){
                for (int i = 0 ; i < 3 ; i++){
                    rotateMatrix(matrix -> matrix, matrix -> size);
                }
                mirrorMatrix(matrix -> matrix, matrix -> size);
            }else if (data -> dir == 3){
                for (int i = 0 ; i < 2 ; i++){
                    rotateMatrix(matrix -> matrix, matrix -> size);
                }
                mirrorMatrix(matrix -> matrix, matrix -> size);

            }else{
                rotateMatrix(matrix -> matrix, matrix -> size);
                mirrorMatrix(matrix -> matrix, matrix -> size);
            }
        }
    }
    

}

void rotateMatrix(int** matrix, int n) {
    for (int i = 0 ; i < n ; i++) {
        for (int j = i + 1 ; j < n ; j++) {
            int temp = matrix[i][j];
            matrix[i][j] = matrix[j][i];
            matrix[j][i] = temp;
        }
    }

    for (int i = 0 ; i < n ; i++) {
        for (int j = 0 ; j < n / 2 ; j++) {
            int temp = matrix[i][j];
            matrix[i][j] = matrix[i][n - j - 1];
            matrix[i][n - j - 1] = temp;
        }
    }
}

void mirrorMatrix(int** matrix, int n) {
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n / 2; j++) {
            // Swap elements across the vertical centerline
            int temp = matrix[i][j];
            matrix[i][j] = matrix[i][n - j - 1];
            matrix[i][n - j - 1] = temp;
        }
    }
}

void moveAndFill(int i, int* value, int** matrix, int* x, int* y){
    if (i % 2 == 1){
        for (int j = 0 ; j < i; j++){
            (*x)--;
            (*value)++;
            matrix[*x][*y] = *value;
        }
        for (int j = 0 ; j < i; j++){
            (*y)++;
            (*value)++;
            matrix[*x][*y] = *value;
        }
    }else{
        for (int j = 0 ; j < i; j++){
            (*x)++;
            (*value)++;
            matrix[*x][*y] = *value;
        }
        for (int j = 0 ; j < i; j++){
            (*y)--;
            (*value)++;
            matrix[*x][*y] = *value;
        }
    }
}
