import random

key = []
gen = []
gamma = []

# штука для генерации ключа
def generate_key():
  for i in range(256):
    key.append(i)
  random.shuffle(key)
  for i in range(256):
    gen.append(key[i])

# штука для генерации рандомных чиселок
def generation_random_numbers():
  j = 0
  for i in range(256):
    j = (j + gen[i] + key[i]) % 256
    gen[j], gen[i] = gen[i], gen[j]
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
  return gamma

#перевод строки в последовательность нулей и единиц
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
  return result

#преобразование последовательности нулей и единиц в число
def bin2str(message):
  symbols = ""
  num = 0
  # пока не закончится строка
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
  return symbols

# зашифровка
def encrypt(message, gamm):
  bytes = []
  for i in range(len(message)):
    bytes.append(message[i] ^ gamm[i])
  return bytes

# расшифровка
def decrypt(message, gamm):
  bytes = []
  for i in range(len(message)):
    bytes.append(message[i] ^ gamm[i])
  return bytes


def main():
  print("\n Лабораторная №4. Блочные шифры\n")
  generate_key()

  print("KEY: ", key[:10])

  generation_random_numbers()
  print("GEN: ", gen[:10])

  print()
  print("Enter message: ")
  message = input()
  # 

  print()
  # здесь ord возвращает целое число unicode символа
  print("Message:", [ord(letter) for letter in message])

  print()
  # полученная строка переводится в число, записываем в лист
  split = str2bin(message)
  print("Message to bin number:\n", split)

  print()
  # генерим гамму
  make_gamma(split, gen)
  print("Gamma:\n", gamma)

  print()
  # щифруем
  enc = encrypt(split, gamma)
  print("Encrypt message:\n", enc)

  print()
  # переводим число в строку, тут белиберда
  # так и нужно
  symbols = bin2str(enc)
  print("New message: ", symbols)

  print()

  # здесь мы уже начинаем расшифровывать белиберду
  unsplit = str2bin(symbols)
  #тут последовательность, чиселки как в прошлом шаге
  print("New message 2ns:\n", unsplit)

  print()
  # расшифровка
  decr = decrypt(unsplit, gamma)
  print("Descrypt message:\n", decr)

  print()
  # и снова чиселки переводим в сообщение
  end = bin2str(decr)
  print("Your message:\n", end)

  print()


if __name__ == '__main__':
  main()
