import random

key = []
gen = []
gamma = []

#генерация ключа, перестановка от 0 до 255
def generate_key():
  for i in range(256):
    key.append(i)
  random.shuffle(key)
  for i in range(256):
    gen.append(key[i])
  print("KEY: ", key[:10])

#инициализация генератора рандомных чисел 
def generation_random_numbers():
  j = 0
  for i in range(256):
    j = (j + gen[i] + key[i]) % 256
    #меняем местами
    gen[j], gen[i] = gen[i], gen[j]
  
  print("GEN: ", gen[:10])
  return gen

#получение гаммы
def make_gamma(message, gen):
  temp = gen

  i, j = 0, 0
  for k in range(len(message)):
    i = (i + 1) % 256
    j = (j + temp[i]) % 256
    #меняем местами
    temp[i], temp[j] = temp[j], temp[i]
    t = (temp[i] + temp[j]) % 256
    gamma.append(temp[t])
  
  print("Gamma:\n", gamma)
  return gamma

#перевод строки в биты
def str2bin(message):
  list = []

  for i in range(len(message)):
    list.append(bin(ord(message[i]))[2:].zfill(16)[:8])
    list.append(bin(ord(message[i]))[2:].zfill(16)[8:])

  result = []

  for elem in list:
    num = 0
    str = elem[::-1]  # переворачиваем elem
    for i in range(len(str)):
      num += int(str[i]) * (2 ** i)
    result.append(num)
    
  print("New message 2ns:\n", unsplit)
  return result

#биты в число
def bin2str(message):
  symbols = ""
  num = 0
  #до конца строки
  while num < len(message):
    bit1 = bin(message[num])[2:].zfill(8)
    bit2 = bin(message[num+1])[2:].zfill(8)

    number = bit1 + bit2
    number = number[::-1]
    
    bit = 0
    for i in range(len(number)):
      bit += int(number[i]) * (2 ** i)

    symbols += chr(bit)
    num += 2
  
  print("Message: ", symbols)
  return symbols

# зашифровка - {OR сообщения и гаммы
def encrypt(message, gamm):
  bytes = []
  for i in range(len(message)):
    bytes.append(message[i] ^ gamm[i])
  
  print("Encrypt message:\n", enc)
  return bytes

# расшифровка сообщения - XOR зашифрованного сообщения и гаммы
def decrypt(message, gamm):
  bytes = []
  for i in range(len(message)):
    bytes.append(message[i] ^ gamm[i])
  
  print("Descrypt message:\n", decr)
  return bytes


def main():
  #генерация ключа
  generate_key()

  #инициализация генератора случайных чисел
  generation_random_numbers()

  #получаем сообщение
  print()
  print("Enter message: ")
  message = input()
  # 

  print()
  #ord возвращает целое число unicode символа
  print("Message:", [ord(letter) for letter in message])

  print()
  # полученная строка переводится в число, записываем в лист
  split = str2bin(message)
  print("Message to bin number:\n", split)

  print()
  #получение гаммфы
  make_gamma(split, gen)

  print()
  #зашифровываем сооьбщение
  enc = encrypt(split, gamma)

  print()
  #перевод числа в строку
  symbols = bin2str(enc)

  print()

  #переводим строку обратно в двоичное число
  unsplit = str2bin(symbols)
 
  print()
  
  #расшифровка
  decr = decrypt(unsplit, gamma)

  print()
  #переводим число в строку
  end = bin2str(decr)

  print()


if __name__ == '__main__':
  main()
