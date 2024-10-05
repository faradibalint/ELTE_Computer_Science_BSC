-- ! Farádi Bálint - Funkcionális Programozás - Beadandó
module Beadando where


    showState a = show a
    showMage a = show a
    eqMage a b =  a == b
    showUnit a = show a
    showOneVOne a = show a 

    type Name = String
    type Health = Integer
    type Spell = (Integer -> Integer)
    type Army = [Unit]
    type EnemyArmy = Army
    type Amount = Integer

    data State x = Alive x | Dead
        deriving (Eq)
    instance (Show x) => Show (State x) where
        show (Alive x) = show x
        show Dead = "Dead"

    data Entity = Golem Health | HaskellElemental Health
        deriving (Show, Eq)

    data Mage = Master Name Health Spell
    
    instance Show Mage where
        show (Master x y z)
            | y > 4 = x
            | otherwise = "Wounded " ++ x

    instance Eq Mage where
        (==) (Master x y z) (Master xs ys zs)
            | x==xs && y == ys = True
            | otherwise = False

    papi = let 
        tunderpor enemyHP
            | enemyHP < 8 = 0
            | even enemyHP = div (enemyHP * 3) 4
            | otherwise = enemyHP - 3
        in Master "Papi" 126 tunderpor
    java = Master "Java" 100 (\x ->  x - (mod x 9))
    traktor = Master "Traktor" 20 (\x -> div (x + 10) ((mod x 4) + 1))
    jani = Master "Jani" 100 (\x -> x - div x 4)
    skver = Master "Skver" 100 (\x -> div (x+4) 2)
    potionMaster = 
        let plx x
                | x > 85  = x - plx (div x 2)
                | x == 60 = 31
                | x >= 51 = 1 + mod x 30
                | otherwise = x - 7 
        in Master "PotionMaster" 170 plx
    
    data Unit = M (State Mage) | E (State Entity)
        deriving (Eq)

    instance Show Unit where
        show (M a) = show a
        show (E b) = show b

    formationFix :: Army -> Army
    formationFix x = [y | y <- x, y /= (M Dead) && y /= (E Dead)] ++ [y | y <- x, y == (M Dead) || y == (E Dead)] 

    over :: Army -> Bool
    over x = all (\x -> x==(E Dead) || x==(M Dead)) x

    fight :: EnemyArmy -> Army -> Army
    fight [] a = a
    fight _ [] = []
    fight ((E Dead):xs) (y:ys) = y : fight xs ys
    fight ((M Dead):xs) (y:ys) = y : fight xs ys
    fight ((E(Alive(Golem n))):xs) (y:ys) = hit (\x -> x-1) y : fight xs ys
    fight ((E(Alive(HaskellElemental n))):xs) (y:ys) = hit (\x -> x-3) y : fight xs ys
    fight ((M(Alive(Master name hp spell))):xs) (y:ys) = hit spell y : fight xs [hit spell yy | yy <- ys]

    hit::(Health->Health)->Unit->Unit
    hit spell (E(Alive(Golem n)))
        | spell n < 1 = E Dead
        | otherwise = E(Alive(Golem (spell n)))
    hit spell (E(Alive(HaskellElemental n)))
        | spell n < 1 = E Dead
        | otherwise = E(Alive(HaskellElemental (spell n)))
    hit spell (M(Alive(Master name hp spel)))
        | spell hp < 1 = M Dead
        | otherwise = M(Alive(Master name (spell hp) spel))
    hit _ (E Dead) = E Dead
    hit _ (M Dead) = M Dead


    haskellBlast :: Army -> Army
    haskellBlast [] = []
    haskellBlast y@(x:xs)
        | fromPosition (take 5 y) == maxindex y  = map (hit (\x -> x-5)) (take 5 y) ++ drop 5 y
        | otherwise = x : haskellBlast xs
            where
                maxindex :: Army -> Integer
                maxindex army = maximum [fromPosition (take 5 (drop x army)) | x <- [0..length army-1]]
    --haskellBlast (x:xs) = hit (\x -> x-5) x : haskellBlast xs

    fromPosition :: Army -> Integer
    fromPosition x = temp x 0
        where
            temp :: Army -> Integer -> Integer
            temp [] _ = 0
            temp (x:xs) y
                | y < 5 && getHp x > 5 = 5 + temp xs (y+1)
                | y < 5 && getHp x < 6 = getHp x + temp xs (y+1)
                    where 
                        getHp :: Unit -> Integer
                        getHp (E Dead) = 0
                        getHp (M Dead) = 0
                        getHp (E(Alive(Golem n))) = n
                        getHp (E(Alive(HaskellElemental n))) = n
                        getHp (M(Alive(Master name hp spell))) = hp


    multiHeal :: Health -> Army -> Army
    multiHeal _ [] = []
    multiHeal _ y@(x:xs)
        | all (\x -> x == (E Dead) || x == (M Dead)) y = y
    multiHeal y x
        | y > 0 =  multiHeal (y-(dodo y x)) (doo y x)
        | otherwise = x
        where
            doo :: Health -> Army -> Army
            doo _ [] = []
            doo y ((M Dead):xs) = (M Dead) : doo y xs
            doo y ((E Dead):xs) = (E Dead) : doo y xs
            doo y (x:xs)
                | y > 0 = heal (\x -> x + 1) x : doo (y-1) xs
                | otherwise = x:xs 
            dodo :: Health -> Army -> Health
            dodo _ [] = 0
            dodo y ((M Dead):xs) = dodo y xs
            dodo y ((E Dead):xs) = dodo y xs
            dodo y (x:xs)
                | y > 0 = 1 + dodo (y-1) xs
                | otherwise = 0

    heal :: (Health->Health)->Unit->Unit
    heal spell (E(Alive(Golem n))) = E(Alive(Golem (spell n)))
    heal spell (E(Alive(HaskellElemental n))) = E(Alive(HaskellElemental (spell n)))
    heal spell (M(Alive(Master name hp spel))) = M(Alive(Master name (spell hp) spel))
    heal _ (E Dead) = E Dead
    heal _ (M Dead) = M Dead

    chain :: Amount -> (Army, EnemyArmy) -> (Army, EnemyArmy)
    chain _ ([],[]) = ([],[])
    chain h ([],y@(ys:yz)) = ([],y)
    chain h (x@(xs:xz),[]) = ((heal (\x -> x+h) xs):xz,[])
    chain h (x@(xs:xz), y@(ys:yz))
        | h > 0 && not (null x) && not (null y) && (xs == (E Dead) || xs == (M Dead)) && (ys == (E Dead) || ys == (M Dead)) = addPairToList (xs, ys) (chain (h) (xz,yz))
        | h > 0 && not (null x) && not (null y) && (ys == (E Dead) || ys == (M Dead)) = addPairToList (heal (\x -> x+h) xs, ys) (chain (h-1) (xz,yz))
        | h > 0 && not (null x) && not (null y) && (xs == (E Dead) || xs == (M Dead)) = addPairToList (xs, hit (\x -> x-h) ys) (chain (h-1) (xz,yz))
        | h > 0 && not (null x) && not (null y) = addPairToList (heal (\x -> x+h) xs, hit (\x -> x-(h-1)) ys) (chain (h-2) (xz,yz))
        | h > 0 && not (null x) && null y = ((heal (\x -> x+h) xs) : xz, [])
        | otherwise = (x,y)
    
    addPairToList :: (Unit, Unit) -> (Army, EnemyArmy) -> (Army ,EnemyArmy)
    addPairToList (x, y) (xs, ys) = (x:xs, y:ys)

    data OneVOne = Winner String | You Health OneVOne | HaskellMage Health OneVOne deriving Eq

    instance Show OneVOne where
        show a = "<" ++ doo a ++ ">"
            where
                doo :: OneVOne -> String
                doo (Winner x) = "|| Winner " ++ x ++ " ||"
                doo (You hp next) = "You " ++ show hp ++ "; " ++ doo next
                doo (HaskellMage hp next) = "HaskellMage " ++ show hp ++ "; " ++ doo next


    battle :: Army -> EnemyArmy -> Maybe Army
    battle [] [] = Nothing
    battle army [] = Just army
    battle [] enemyArmy = Just enemyArmy
    battle army enemyArmy
        | areAllDead army && areAllDead enemyArmy = Nothing
        | areAllDead army = Just enemyArmy
        | areAllDead enemyArmy = Just army
        | otherwise = battle (sortOut(round army enemyArmy)) (sortOut(fight army enemyArmy))
        where
            round :: Army -> EnemyArmy -> Army
            round army enemyarmy = multiHeal 20 (haskellBlast (fight enemyArmy army))
            

    battleWithChain :: Army -> EnemyArmy -> Maybe Army {- vagy Maybe EnemyArmy -}
    battleWithChain [] [] = Nothing
    battleWithChain army [] = Just army
    battleWithChain [] enemyArmy = Just enemyArmy
    battleWithChain army enemyArmy
        | areAllDead army && areAllDead enemyArmy = Nothing
        | areAllDead army = Just enemyArmy
        | areAllDead enemyArmy = Just army
        | otherwise = battleWithChain (sortOut(fst (fullRound army enemyArmy))) (sortOut(snd (fullRound army enemyArmy)))
        where
            round :: Army -> EnemyArmy -> Army
            round army enemyarmy = multiHeal 20 (haskellBlast (fight enemyArmy army))
            fullRound :: Army -> EnemyArmy -> (Army, EnemyArmy)
            fullRound army enemyArmy = chain 5 (round army enemyArmy, fight army enemyArmy)

    sortOut :: Army -> Army
    sortOut army = alive army ++ dead army 
    alive :: Army -> Army
    alive = filter (not . isDead)
    dead :: Army -> Army
    dead = filter isDead
    isDead :: Unit -> Bool
    isDead (E Dead) = True
    isDead (M Dead) = True
    isDead _ = False
    areAllDead :: Army -> Bool
    areAllDead = all isDead

    finalBattle :: Health -> Health -> OneVOne
    finalBattle 0 0 = (HaskellMage 0(Winner "You"))
    finalBattle y x -- ! azért vannak megcserélve a apraméterrek a roundshoz képest mert fordítva írtam meg a függvényt és így volt a legegyszerűbb kijavítani
        | y <= 0 = (Winner "You")
        | x <= 0 = (Winner "HaskellMage")
        | otherwise = rounds 2 x y
            where
                rounds :: Int -> Health -> Health -> OneVOne
                rounds z x y 
                    | z == 2 = ((HaskellMage (x)(haskellMageRound z x y)))
                    | x > 0 && y > 0 && even z = haskellMageRound z x y 
                    | x > 0 && y > 0 && odd z = youRound z x y
                    | otherwise = finalBattle x y
                        where
                            haskellMageRound z x y
                                | x < 4 && (div y 2) > 0 = ((You (div y 2)(rounds (z+1) (x*4) (div y 2))))
                                | x < 4 && (div y 2) <= 0 = ((You (0)(rounds (z+1) (x*4) (0))))
                                | y > 20 && div (y*3) 4 > 0  = ((You (div (y*3) 4)(rounds (z+1) (x) (div (y*3) 4))))
                                | y > 20 && div (y*3) 4 <= 0  = ((You (0)(rounds (z+1) (x) (0))))
                                | (y-11) <= 0 = ((You (0)(rounds (z+1) (x) (0))))
                                | otherwise = ((You (y-11)(rounds (z+1) (x) (y-11))))
                            youRound z x y
                                | y < 4 = ((HaskellMage (x)(rounds (z+1) (x) (4*y))))
                                | x > 15 && div (3*x) 5 > 0= ((HaskellMage (div (3*x) 5)(rounds (z+1) (div (3*x) 5) (y))))
                                | x > 15 && div (3*x) 5 <= 0 = ((HaskellMage (0)(rounds (z+1) (0) (y))))
                                | (x-9) <= 0 = ((HaskellMage (0)(rounds (z+1) (0) (y))))
                                | otherwise = ((HaskellMage (x-9)(rounds (z+1) (x-9) (y))))
     

                    
    --rounds 2 500 500
    --haskellMageRound 2 500 500
    --(HaskellMage 500(You 375 (  )))
    --rounds (3) (500) (375)
    --youRound 3 500 375
    --(HaskellMage (div (1500) 5)(You (375)(rounds (z+1) (div (3*x) 5) (y))))



                    
        
                    
