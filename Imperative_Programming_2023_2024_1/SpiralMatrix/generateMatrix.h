#ifndef MATRIX_GENERATE_H
#define MATRIX_GENERATE_H

#include "main.h"

typedef struct _Matrix_Properties Matrix_Properties;
typedef enum _direction direction;
typedef enum _rotation rotation;

enum _direction {
    balra,
    fel,
    jobbra,
    le
};

enum _rotation{
    cw,
    ccw
};

struct _Matrix_Properties{
    int size;
    direction dir;
    rotation rotate;
};

void callGenerateMatrix(Matrix* my_matrix);
void fillMatrix(Matrix* matrix, Matrix_Properties* data);
void rotateMatrix(int** matrix, int n);
void mirrorMatrix(int** matrix, int n);
void moveAndFill(int i, int* value, int** matrix, int* x, int* y);


#endif //MATRIX_GENERATE_H