module Vizsga where

    import Data.List

    type Difficulty = Int
    type Elderflower = (Difficulty, Bool)
    type ElderberryBush = [Elderflower]
    type Trail = [ElderberryBush] -- azaz [[(Int, Bool)]]

    --elderflowerPicking :: Trail -> Difficulty -> Int
    elderflowerPicking [] _ = 0
    elderflowerPicking (x:xs) y
        | not (null x) && any (\(a,b) -> a <= y && b == True) x = count x y + elderflowerPicking xs y
        | otherwise = elderflowerPicking xs y
            where
                count [] _ = 0
                count (x:xs) y
                    | fst x <= y && (snd x) == True = 1 + count xs y
                    | otherwise = count xs y  

    summarize :: Integral a => [(String, a, a)] -> [(String, a)]
    summarize [] = []   
    summarize ((x,y,z):xs)
        | z < 10 = (x,y+z*5) : summarize xs
        | otherwise = summarize xs

    haveAll :: Eq a => [a] -> [a] -> Bool
    haveAll [] _ = True
    haveAll (x:xs) [] = False
    haveAll z@(x:xs) (y:ys)
        | x == y = True && haveAll xs ys
        | otherwise = haveAll z ys

    kensTrousers :: [String] -> Maybe String
    kensTrousers x = accum 1 x
        where
            accum _ [] = Nothing
            accum y (x:xs)
                | x == "vilagoskek" = Just x
                | x /= "fekete" && mod y 2 == 0 = Just x
                | otherwise = accum (y+1) xs

    first :: [a -> Bool] -> a -> Int
    first [] _ = 0
    first z@(x:xs) y = accum 1 z y
        where
            accum :: Int -> [a -> Bool] -> a -> Int
            accum _ [] _ = 0
            accum k (x:xs) y
                | x y = k
                | otherwise = accum (k+1) xs y

    combineListsIf :: (a -> b -> Bool) -> (a -> b -> c) -> [a] -> [b] -> [c]
    combineListsIf _ _ [] _ = []
    combineListsIf _ _ _ [] = []
    combineListsIf pred f (x:xs) (y:ys)
        | pred x y = f x y : combineListsIf pred f xs ys
        | otherwise = combineListsIf pred f xs ys

    data Line = Tram Integer [String] | Bus Integer [String]
        deriving (Show, Eq)

    whichTramStop :: String -> [Line] -> [Integer]
    whichTramStop _ [] = []
    whichTramStop y ((Tram z kk):xs)
        | any (==y) kk = z : whichTramStop y xs
        | otherwise = whichTramStop y xs
    whichTramStop y (x:xs) = whichTramStop y xs

    isBookable :: Int -> [Int] -> Bool
    isBookable x []
        | x == 0 = True
        | otherwise = False
    isBookable y i@(x:xs)
        | isPrefixOf (replicate y 0) i = True
        | otherwise = isBookable y xs