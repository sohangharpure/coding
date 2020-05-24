def dpMakeChange(coinValueList,change,minCoins,coinsUsed):
   for cents in range(change+1):
      coinCount = cents
      newCoin = 1
      for j in [c for c in coinValueList if c <= cents]:
            if minCoins[cents-j] + 1 < coinCount:
               coinCount = minCoins[cents-j]+1               
               newCoin = j
      minCoins[cents] = coinCount
      coinsUsed[cents] = newCoin
   return minCoins[change]

def dpMinAmountOfChange(target, coins):
   minCoins = [0] * (target+1)
   for amount in range(target+1):
      coinCount = amount
      for coin in [c for c in coins if c <= amount]:
         if minCoins[amount-coin] + 1 < coinCount:
            coinCount = minCoins[amount-coin] + 1
      minCoins[amount] = coinCount
   return minCoins[target]      

def dpNoOfWaysToMakeChange(target,coins):
   ways = [0] * (target+1)
   ways[0] = 1
   for coin in coins:
      for amount in range(1, target+1):
         if coin <= amount:
            ways[amount] += ways[amount-coin]
   return ways[target]            

def printCoins(coinsUsed,change):
   coin = change
   while coin > 0:
      thisCoin = coinsUsed[coin]
      print(thisCoin)
      coin = coin - thisCoin

def main():
    amnt = 63
    clist = [1,5,10,21,25]
    coinsUsed = [0]*(amnt+1)
    coinCount = [0]*(amnt+1)

    print("Making change for",amnt,"requires")
    print(dpMakeChange(clist,amnt,coinCount,coinsUsed),"coins")
    """    
    print("They are:")
    printCoins(coinsUsed,amnt)
    print("The used list is as follows:")
    print(coinsUsed) """
    print(dpMinAmountOfChange(5, [1,5]))

main()