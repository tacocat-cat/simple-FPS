import random
import pygame

# Define some constants.
SCREEN_WIDTH = 800
SCREEN_HEIGHT = 600
PLAYER_SPEED = 5
BULLET_SPEED = 10

# Create a Pygame window.
screen = pygame.display.set_mode((SCREEN_WIDTH, SCREEN_HEIGHT))

# Create the player sprite.
player = pygame.sprite.Sprite()
player.image = pygame.Surface((32, 32))
player.image.fill((255, 0, 0))
player.rect = player.image.get_rect()
player.rect.center = (SCREEN_WIDTH / 2, SCREEN_HEIGHT / 2)

# Create a list to store the bullets.
bullets = []

# Start the game loop.
while True:

  # Handle events.
  for event in pygame.event.get():
    if event.type == pygame.QUIT:
      pygame.quit()
      sys.exit()

    # Handle keyboard input.
    if event.type == pygame.KEYDOWN:
      if event.key == pygame.K_UP:
        player.rect.y -= PLAYER_SPEED
      elif event.key == pygame.K_DOWN:
        player.rect.y += PLAYER_SPEED
      elif event.key == pygame.K_LEFT:
        player.rect.x -= PLAYER_SPEED
      elif event.key == pygame.K_RIGHT:
        player.rect.x += PLAYER_SPEED

      # Fire a bullet.
      elif event.key == pygame.K_SPACE:
        bullet = pygame.sprite.Sprite()
        bullet.image = pygame.Surface((10, 10))
        bullet.image.fill((255, 255, 255))
        bullet.rect = bullet.image.get_rect()
        bullet.rect.center = player.rect.center
        bullet.speedx = 0
        bullet.speedy = -BULLET_SPEED
        bullets.append(bullet)

  # Update the player's position.
  player.rect.clamp_ip(screen.get_rect())

  # Update the bullets' positions.
  for bullet in bullets:
    bullet.rect.y += bullet.speedy

    # If the bullet goes off the screen, remove it from the list.
    if bullet.rect.y < 0:
      bullets.remove(bullet)

  # Draw the screen.
  screen.fill((0, 0, 0))
  screen.blit(player.image, player.rect)
  for bullet in bullets:
    screen.blit(bullet.image, bullet.rect)

  # Update the display.
  pygame.display.flip()


This is just a very basic FPS game. You can add many more features, such as enemies, levels, and weapons.