import math
import random

# вычисление обратного числа по модулю n 
# нужно для вычисления d
def inv(a, n): 
  if (a % n) != 0:
    result = 1
    while True:
      if ((result * a) % n) == 1:
        return result
      else:
        result += 1
  else:
    return None

# зашифрование
def encrypt(message, keys):
  pk = keys[0]
  e = pk[0]
  n = pk[1]
  result = (message ** e) % n
  return int(result)

# дешифрование
def decrypt(message, keys):
  
  sk = keys[1]
  n = sk[1]
  d = sk[0]
  result = (message ** d) % n

  return int(result)


def main():

    print("\nRSA\n")

    p = 13
    q = 17

    # тут вычисляем ключи
    n = p * q

    ############################# ПЕРВЫЙ КЛЮЧ
    # эйлер
    eiler = (q - 1) * (p - 1)

    # от нуля до произведения p*q
    e = random.randint(3, n - 1)

    gcd = math.gcd(e, eiler)

    while gcd != 1:
        e = random.randint(3, n - 1)
        gcd = math.gcd(e, eiler)

    ############################# ВТОРОЙ КЛЮЧ
    d = inv(e, eiler)
    if d is None:
        return print("error")

    # сами ключи
    pk = (e, n)
    sk = (d, n)

    keys = pk, sk

    print("Ключи: ", keys)

    message = 14
    print("Исходное сообщение: ", message)

    enc = encrypt(message, keys)
    print("Зашифрованное сообщение: ", enc)

    dec = decrypt(enc, keys)
    print("Разшифрованное сообщение: ", dec)

    print()


if __name__ == '__main__':
  main()
